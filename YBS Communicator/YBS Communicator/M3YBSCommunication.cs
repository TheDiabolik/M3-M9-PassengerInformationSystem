using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace M3YBSCommunication
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class M3YBSCommunication : IM3YBSCommunication
    {
        private static Timer m_timerM3YBSCommunication = new Timer(OnTimerElapsed, null, 0, 1000);
        private static Stopwatch m_stopWatchMPUConnection = new Stopwatch();
        private static Stopwatch m_stopWatchMPU_REDConnection = new Stopwatch();
        private static Stopwatch m_stopWatchConnectionController = new Stopwatch();

        private static int counter = 0;

        private static ConcurrentQueue<ICallbackMPUStatus> m_toBeDeleted = new ConcurrentQueue<ICallbackMPUStatus>();

        private static ThreadSafeList<ICallbackMPUStatus> m_notifySubscribers = new ThreadSafeList<ICallbackMPUStatus>();
        private static ThreadSafeList<MPU> m_redundancyMPUs = new ThreadSafeList<MPU>();

        private static string m_mpuStatus;
        public string MpuStatus
        {
            get { return m_mpuStatus; }
            set
            {
                m_mpuStatus = value;
            }
        }

        private static string m_mpuRedStatus;
        public string MpuRedStatus
        {
            get { return m_mpuRedStatus; }
            set
            {
                m_mpuRedStatus = value;
            }
        }

        string m_status;

        private static string m_masterMPUName;

        public string MasterMPUName
        {
            get { return m_masterMPUName; }
            set
            {
                if (value != m_masterMPUName)
                {
                    m_masterMPUName = value;

                    MPU masterMPU = m_redundancyMPUs.Find(x => x.communication.ToString() == m_masterMPUName);

                    MPU slaveMPU = m_redundancyMPUs.Find(x => x.communication.ToString() != m_masterMPUName);

                    if (masterMPU != null)
                        masterMPU.MPUType = Enums.MPUType.Master;

                    if (slaveMPU != null)
                        slaveMPU.MPUType = Enums.MPUType.Slave;
                }
            }
        }


        private static void OnTimerElapsed(object sender)//, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Servis Çalışıyor.");
            Debug.WriteLine("Servis Çalışıyor.");

            Console.WriteLine("Bağlı Dinleyici Sayısı : " + m_notifySubscribers.Count().ToString());
            Debug.WriteLine("Bağlı Dinleyici Sayısı : " + m_notifySubscribers.Count().ToString());

            Console.WriteLine("Yedeklilik Listesindeki MPU Sayısı : " + m_redundancyMPUs.Count().ToString());
            Debug.WriteLine("Yedeklilik Listesindeki MPU Sayısı : " + m_redundancyMPUs.Count().ToString()); 

            Console.WriteLine("MPU : " + m_mpuStatus);
            Debug.WriteLine("MPU : " + m_mpuStatus);

            Console.WriteLine("MPU_RED : " + m_mpuRedStatus);
            Debug.WriteLine("MPU_RED : " + m_mpuRedStatus);

            try
            {
                counter++;

                foreach (ICallbackMPUStatus callBack in m_notifySubscribers)
                {
                    if (((ICommunicationObject)callBack).State == CommunicationState.Opened)
                    {
                        if (counter >= 15)
                            callBack.VB_DRS_OpenDoorsLeftChanged(true);

                        Console.WriteLine("İstemci Bağlı");
                        Debug.WriteLine("İstemci Bağlı");
                    }
                    else
                    {
                        m_toBeDeleted.Enqueue(callBack);
                    }
                }

                int deleteNotifyCount = 0;

                while (m_toBeDeleted.TryDequeue(out ICallbackMPUStatus deletedCallBack))
                {
                    bool deleteNotify = m_notifySubscribers.Remove(deletedCallBack);

                    if (!deleteNotify)
                    {
                        m_toBeDeleted.Enqueue(deletedCallBack);

                        deleteNotifyCount++;    
                    }
                    else
                    {
                        Console.WriteLine("Kapalı Olan Dinleyici Sayısı : " + m_notifySubscribers.Count().ToString());
                        Debug.WriteLine("Kapalı Olan Dinleyici Sayısı : " + m_notifySubscribers.Count().ToString());
                    }

                    if (deleteNotifyCount > 3)
                    {
                        deleteNotifyCount = 0;
                        break;
                    }
                     

                }

                //MPU bağlantı düşme kontrolü
                if (m_stopWatchMPUConnection.Elapsed.TotalSeconds > 8)
                {
                    m_stopWatchMPUConnection.Stop();
                    m_stopWatchMPUConnection.Reset();

                    MPU MPU = m_redundancyMPUs.Find(x => x.communication.ToString() == "MPU");

                    if (MPU != null)
                    {
                        MPU.MPUType = Enums.MPUType.Undefined;
                        MPU.connection = Enums.Connection.CONNECTION_LOST;
                    }
                }

                //MPU_RED bağlantı düşme kontrolü
                if (m_stopWatchMPU_REDConnection.Elapsed.TotalSeconds > 8)
                {
                    m_stopWatchMPU_REDConnection.Stop();
                    m_stopWatchMPU_REDConnection.Reset();

                    MPU MPU_RED = m_redundancyMPUs.Find(x => x.communication.ToString() == "MPU_RED");

                    if (MPU_RED != null)
                    {
                        MPU_RED.MPUType = Enums.MPUType.Undefined;
                        MPU_RED.connection = Enums.Connection.CONNECTION_LOST;
                    }
                }

                if (counter >= 15)
                    counter = 0;

                Console.WriteLine("Bağlı Dinleyici Sayısı : " + m_notifySubscribers.Count().ToString());
                Debug.WriteLine("Bağlı Dinleyici Sayısı : " + m_notifySubscribers.Count().ToString());

                Console.WriteLine("Yedeklilik Listesindeki MPU Sayısı : " + m_redundancyMPUs.Count().ToString());
                Debug.WriteLine("Yedeklilik Listesindeki MPU Sayısı : " + m_redundancyMPUs.Count().ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine("OnTimerElapsed : " + ex.ToString());
            }
        }

        public bool Subscribe()
        {
            bool returnValue = false;

            ICallbackMPUStatus callBack = OperationContext.Current.GetCallbackChannel<ICallbackMPUStatus>();

          
            if (!m_notifySubscribers.Contains(callBack))
            {
                m_notifySubscribers.Add(callBack);
                returnValue = true;

                m_status = "İstemci Listesine Yeni İstemci Eklendi.";
            }
            else
            {
                m_status = "İstemci Listesinde Zaten Ekli!";

                returnValue = false;
            }

            Console.WriteLine(m_status);
            Debug.WriteLine(m_status);

            return returnValue;
        }

        public MPU AddOrFindInRedundancyMPU(MPU communicationMPU)
        {
            MPU returnValue1 = null;

            MPU findingMPU = m_redundancyMPUs.Find(x => x.communication == communicationMPU.communication);

            if ((findingMPU == null))
            {
                returnValue1 = new MPU();

                returnValue1.communication = communicationMPU.communication;
                returnValue1.MPUType = communicationMPU.MPUType;
                returnValue1.connection = communicationMPU.connection;

                m_redundancyMPUs.Add(returnValue1);

                Console.WriteLine("MPU Yedeklilik Listesine Yeni İstemci Eklendi.");
                Debug.WriteLine("MPU Yedeklilik Listesine Yeni İstemci Eklendi.");

                Console.WriteLine("Yedeklilik Listesindeki MPU Sayısı : " + m_redundancyMPUs.Count().ToString());
                Debug.WriteLine("Yedeklilik Listesindeki MPU Sayısı : " + m_redundancyMPUs.Count().ToString());
            }
            else if (findingMPU != null)
            {
                Console.WriteLine("Yedeklilik Listesinde Zaten Ekli!");
                Debug.WriteLine("Yedeklilik Listesinde Zaten Ekli!");
                returnValue1 = findingMPU;
            }

            return returnValue1;
        }

        public bool Unsubscribe()
        {
            ICallbackMPUStatus callBack = OperationContext.Current.GetCallbackChannel<ICallbackMPUStatus>();

            bool returnValue = m_notifySubscribers.Remove(callBack);

            if (returnValue)
            {
                Console.WriteLine("İstemci Listesinden İstemci Çıkartıldı!");

                Console.WriteLine("Yedeklilik Listesindeki MPU Sayısı : " + m_redundancyMPUs.Count().ToString());
                Debug.WriteLine("Yedeklilik Listesindeki MPU Sayısı : " + m_redundancyMPUs.Count().ToString());
            }

            return returnValue;
        }

        public string HeartBeat(string heartBeat)
        {
            string response = "";

            if (heartBeat == "AREUALIVE")
                response = "IMALIVE";

            Console.WriteLine("IMALIVE");

            return response;
        }

        public string HeartBeatWithConnectionCheck(string heartBeat, Enums.Communication communication, Enums.Connection connection)
        {
            string response = "";

            if (heartBeat == "AREUALIVE")
                response = "IMALIVE";

            Console.WriteLine("IMALIVE");

            if ((communication == Enums.Communication.MPU) && (connection == Enums.Connection.CONNECTED))
            {
                m_stopWatchMPUConnection.Restart();
                Console.WriteLine("MPU Bağlantı Kontrolcüsü Başladı!");
            }
            else if ((communication == Enums.Communication.MPU_RED) && (connection == Enums.Connection.CONNECTED))
            {
                m_stopWatchMPU_REDConnection.Restart();
                Console.WriteLine("MPU_RED Bağlantı Kontrolcüsü Başladı!");
            }

            return response;
        }

        public string HeartBeatWithConnectionAndMPUStatusCheck(string heartBeat, Enums.Communication communication, Enums.Connection connection, Enums.MPUType mpuType)
        {
            string response = "";

            if (heartBeat == "AREUALIVE")
                response = "IMALIVE";

            Console.WriteLine("IMALIVE");

            if ((communication == Enums.Communication.MPU) && (connection == Enums.Connection.CONNECTED))
            {
                m_stopWatchMPUConnection.Restart();
                Console.WriteLine("MPU Bağlantı Kontrolcüsü Başladı!");
            }
            else if ((communication == Enums.Communication.MPU_RED) && (connection == Enums.Connection.CONNECTED))
            {
                m_stopWatchMPU_REDConnection.Restart();
                Console.WriteLine("MPU_RED Bağlantı Kontrolcüsü Başladı!");
            }


            if (communication == Enums.Communication.MPU)
            {
                if(mpuType == Enums.MPUType.Master)
                {
                    MpuStatus = "Master";
                    MpuRedStatus = "Slave";
                }
                else if(mpuType == Enums.MPUType.Slave)
                {
                    MpuStatus = "Slave";
                    MpuRedStatus = "Master";
                }
            }

            if (communication == Enums.Communication.MPU_RED)
            {
                if (mpuType == Enums.MPUType.Master)
                {
                    MpuRedStatus = "Master";
                    MpuStatus = "Slave";
                }
                else if (mpuType == Enums.MPUType.Slave)
                {
                    MpuRedStatus = "Slave";
                    MpuStatus = "Master";
                }
            }

            return response;
        }

        public void RedundancyMPUName(Enums.Communication communication, Enums.MPUType type)
        {
            if ((communication == Enums.Communication.MPU) && (type == Enums.MPUType.Master))
            {
                MasterMPUName = communication.ToString();
            }
            else if ((communication == Enums.Communication.MPU_RED) && (type == Enums.MPUType.Master))
            {
                MasterMPUName = communication.ToString();
            }
            else if ((!string.IsNullOrEmpty(MasterMPUName)) && (MasterMPUName == communication.ToString()) && (type != Enums.MPUType.Master))
            {
                MasterMPUName = "";
            }
        }
        
        public void RedundancyState(int redundancyState, string redundancyMPUName)
        {
            if (redundancyState == 1)
            {
                if (redundancyMPUName == "MPU")
                {
                    MasterMPUName = Enums.Communication.MPU.ToString();

                    MpuStatus = "Master";
                    MpuRedStatus = "Slave";

                }
                else
                {
                    MasterMPUName = Enums.Communication.MPU_RED.ToString();

                    MpuStatus = "Slave";
                    MpuRedStatus = "Master";
                }

            }
            else if (redundancyState == 2)
            {

            }
            else
            {
                MasterMPUName = "";
            }
        }

        private void NotifySubscribers(Enums.Communication communication, Enums.Connection connection)
        {
            try
            {
                foreach (ICallbackMPUStatus callBack in m_notifySubscribers)
                {
                    if (((ICommunicationObject)callBack).State == CommunicationState.Opened)
                    {
                        //mpu master slave kontrolü için
                        if ((connection == Enums.Connection.CONNECTION_LOST) && (MasterMPUName == communication.ToString()))
                            MasterMPUName = "";


                        #region update main list mpu connection status
                        MPU findingMPU = m_redundancyMPUs.Find(x => x.communication == communication);

                        if (findingMPU != null)
                            findingMPU.connection = connection;

                        #endregion

                        callBack.MPUConnectionStatusChanged(communication, connection);

                        Console.WriteLine(m_notifySubscribers.Count.ToString() + " Tane Bağlı İstemciye MPU Bağlantı Durumu Gönderildi.");
                        Debug.WriteLine(m_notifySubscribers.Count.ToString() + " Tane Bağlı İstemciye MPU Bağlantı Durumu Gönderildi.");

                        Console.WriteLine("MPU : " + communication.ToString() + " - Bağlantı Durumu : " + connection.ToString());
                        Debug.WriteLine("MPU : " + communication.ToString() + " - Bağlantı Durumu : " + connection.ToString());
                    }
                    else
                    {
                        m_toBeDeleted.Enqueue(callBack);

                        Console.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                        Debug.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("NotifySubscribers : " + ex.ToString());
            }
        }


        private void NotifySubscribersForMPUBehave(Enums.Communication communication, Enums.MPUType MPUType)
        {
            try
            {
                foreach (ICallbackMPUStatus callBack in m_notifySubscribers)
                {
                    if (((ICommunicationObject)callBack).State == CommunicationState.Opened)
                    {
                        RedundancyMPUName(communication, MPUType);

                        callBack.MPUBehaviorChanged(communication, MPUType, MasterMPUName);

                        Console.WriteLine(m_notifySubscribers.Count.ToString() + " Tane Bağlı İstemciye MPU Bağlantı Durumu Gönderildi.");
                        Debug.WriteLine(m_notifySubscribers.Count.ToString() + " Tane Bağlı İstemciye MPU Bağlantı Durumu Gönderildi.");

                        Console.WriteLine("MPU : " + communication.ToString() + " - MPU Davranışı : " + MPUType.ToString());
                        Debug.WriteLine("MPU : " + communication.ToString() + " - MPU Davranışı : " + MPUType.ToString());
                    }
                    else
                    {
                        m_toBeDeleted.Enqueue(callBack);

                        Console.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                        Debug.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("NotifySubscribersForMPUBehave : " + ex.ToString());
            }
        }

        private void NotifySubscribersForMPURedundancyStatus(int redundancyStatus, string MPUName)
        {
            try
            {
                foreach (ICallbackMPUStatus callBack in m_notifySubscribers)
                {
                    if (((ICommunicationObject)callBack).State == CommunicationState.Opened)
                    {
                        RedundancyState(redundancyStatus, MPUName);

                        callBack.MPURedundancyStateChanged(redundancyStatus, MPUName);

                        Console.WriteLine(m_notifySubscribers.Count.ToString() + " Tane Bağlı İstemciye MPU Bağlantı Durumu Gönderildi.");
                        Debug.WriteLine(m_notifySubscribers.Count.ToString() + " Tane Bağlı İstemciye MPU Bağlantı Durumu Gönderildi.");

                        string resultString;

                        if (redundancyStatus == 1)
                            resultString = "MPU : " + MPUName + " - MPU Davranışı : " + "Master";
                        else
                            resultString = "MPU : " + MPUName + " - MPU Davranışı : " + "Slave";

                        Console.WriteLine(resultString);
                        Debug.WriteLine(resultString);
                    }
                    else
                    {
                        m_toBeDeleted.Enqueue(callBack);

                        Console.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                        Debug.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("NotifySubscribersForMPUBehave : " + ex.ToString());
            }
        }
        
        private void NotifySubscribersForResetDistanceCounter(bool value)
        {
            try
            {
                foreach (ICallbackMPUStatus callBack in m_notifySubscribers)
                {
                    if (((ICommunicationObject)callBack).State == CommunicationState.Opened)
                    {
                        callBack.NotifyMasterMPUForResetEVRDistanceStatus(MasterMPUName, value);

                        Console.WriteLine(m_notifySubscribers.Count.ToString() + " Tane Bağlı İstemciye Master MPU Reset Talebi Gönderildi.");
                        Debug.WriteLine(m_notifySubscribers.Count.ToString() + " Tane Bağlı İstemciye Master MPU Reset Talebi Gönderildi.");

                        Console.WriteLine("İstemcilere MPU Reset Talebi Gönderildi.");
                    }
                    else
                    {
                        m_toBeDeleted.Enqueue(callBack);

                        Console.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                        Debug.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("NotifySubscribers : " + ex.ToString());
            }
        }

        private void NotifySubscribersForIncreaseDistanceCounter(int value)
        {
            try
            {
                Console.WriteLine("Distance Counter : " + value);

                foreach (ICallbackMPUStatus callBack in m_notifySubscribers)
                {
                    if (((ICommunicationObject)callBack).State == CommunicationState.Opened)
                    {
                        callBack.EVR_ICountDistChanged(value);
                    }
                    else
                    {
                        m_toBeDeleted.Enqueue(callBack);

                        Console.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                        Debug.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                    }
                }

                Console.WriteLine("İstemcilere Distance Counter Arttırma Talebi Gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("NotifySubscribers : " + ex.ToString());
            }
        }

        private void NotifyVehicleSubcomponentsChanged(string name, object value)
        {
            try
            {
                foreach (ICallbackMPUStatus callBack in m_notifySubscribers)
                {
                    if (((ICommunicationObject)callBack).State == CommunicationState.Opened)
                    {
                        SubcomponentsChanged(callBack, name, value);

                        Console.WriteLine(m_notifySubscribers.Count.ToString() + " Tane Bağlı İstemciye Araç Durumu Değişikliği Gönderildi.");
                        Debug.WriteLine(m_notifySubscribers.Count.ToString() + " Tane Bağlı İstemciye Araç Durumu Değişikliği Gönderildi.");
                    }
                    else
                    {
                        m_toBeDeleted.Enqueue(callBack);

                        Console.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                        Debug.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("VehicleSubcomponentsNotify : " + ex.ToString());
            }
        }


        public void MPUConnectionStatus(Enums.Communication communication, Enums.Connection connection)
        {
            NotifySubscribers(communication, connection);
        }

        public void MPUBehaviorStatus(Enums.Communication communication, Enums.MPUType MPUType)
        {
            NotifySubscribersForMPUBehave(communication, MPUType);
        }

        public void MPURedundancyStatus(int redundancyStatus, string MPUName)
        {
            NotifySubscribersForMPURedundancyStatus(redundancyStatus, MPUName);
        }

        public void ResetDistanceCounter(bool resetCountDist)
        {
            NotifySubscribersForResetDistanceCounter(resetCountDist);
        }

        public void IncreaseDistanceCounter(int increaseCountDist)
        {
            NotifySubscribersForIncreaseDistanceCounter(increaseCountDist);
        }

        public void MPUStatus(MPU mpu)
        {
            try
            {
                MPU existingMPUValues;
                existingMPUValues = m_redundancyMPUs.Find(x => x.communication == mpu.communication);

                if (existingMPUValues != null)
                {
                    PropertyInfo[] existingMPUValuesProperties = existingMPUValues.GetType().GetProperties();
                    PropertyInfo[] MPUValuesProperties = mpu.GetType().GetProperties();

                    for (int i = 0; i < existingMPUValuesProperties.Length; i++)
                    {
                        object existingValue = existingMPUValuesProperties[i].GetValue(existingMPUValues);
                        object mpuValue = MPUValuesProperties[i].GetValue(mpu);

                        if ((existingValue != null) && (mpuValue != null))
                        {
                            bool isEqual = existingValue.Equals(mpuValue);

                            if (!isEqual)
                            {
                                MPUValuesProperties[i].SetValue(existingMPUValues, mpuValue);

                                string valueToGet = Convert.ToString(MPUValuesProperties[i].Name);

                                if (!string.IsNullOrEmpty(valueToGet))
                                {
                                    //master durumu askıya alındığı için mpuda olan değişiklikler gönderilecek
                                    //if (mpu.communication.ToString() == MasterMPUName)
                                    if (mpu.communication.ToString() == Enums.Communication.MPU.ToString())
                                    {
                                        NotifyVehicleSubcomponentsChanged(valueToGet, mpuValue);

                                        Console.WriteLine("MPU : " + mpu.communication.ToString() + " Değişen Durum : " + valueToGet + " " + mpuValue.ToString());

                                        Debug.WriteLine("MPU : " + mpu.communication.ToString() + " Değişen Durum : " + valueToGet + " " + mpuValue.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MPUStatus : " + ex.ToString());
            }
        }

        private void SubcomponentsChanged(ICallbackMPUStatus callback, string name, object value)
        {
            switch (name)
            {
                case "A1VehicleDoorStatus":
                    {
                        bool convertValue = Convert.ToBoolean(value);
                        callback.A1VehicleDoorStatusChanged(convertValue);
                        break;
                    }
                case "A2VehicleDoorStatus":
                    {
                        bool convertValue = Convert.ToBoolean(value);
                        callback.A2VehicleDoorStatusChanged(convertValue);
                        break;
                    }
                case "C1VehicleDoorStatus":
                    {
                        bool convertValue = Convert.ToBoolean(value);
                        callback.C1VehicleDoorStatusChanged(convertValue);
                        break;
                    }
                case "B1VehicleDoorStatus":
                    {
                        bool convertValue = Convert.ToBoolean(value);
                        callback.B1VehicleDoorStatusChanged(convertValue);
                        break;
                    }
                case "VB_DRS_TLLeftDrsReleased":
                    {
                        bool convertValue = Convert.ToBoolean(value);
                        callback.VB_DRS_TLLeftDrsReleasedChanged(convertValue);
                        break;
                    }
                case "VB_DRS_TLRightDrsReleased":
                    {
                        bool convertValue = Convert.ToBoolean(value);
                        callback.VB_DRS_TLRightDrsReleasedChanged(convertValue);
                        break;
                    }
                case "VB_DRS_OpenDoorsLeft":
                    {
                        bool convertValue = Convert.ToBoolean(value);
                        callback.VB_DRS_OpenDoorsLeftChanged(convertValue);
                        break;
                    }
                case "VB_DRS_OpenDoorsRight":
                    {
                        bool convertValue = Convert.ToBoolean(value);
                        callback.VB_DRS_OpenDoorsRightChanged(convertValue);
                        break;
                    }
                case "VI_TBS_TrainSpeedKph":
                    {
                        callback.VI_TBS_TrainSpeedKphChanged(Convert.ToInt32(value));

                        break;
                    }
                case "EVR_ICountDist":
                    {
                        callback.EVR_ICountDistChanged(Convert.ToInt32(value));

                        break;
                    }
                case "EVR_CResetDist":
                    {
                        bool convertValue = Convert.ToBoolean(value);
                        callback.EVR_CResetDistChanged(convertValue);

                        break;
                    }
                case "DD_CMileageKm_1":
                    {
                        callback.DD_CMileageKm_1Changed(Convert.ToInt32(value));

                        break;
                    }
            }

        }

        public void AnnouncementStatus(AnnouncementDTO announcementDTO)
        {
            try
            {
                foreach (ICallbackMPUStatus callBack in m_notifySubscribers)
                {
                    if (((ICommunicationObject)callBack).State == CommunicationState.Opened)
                    {
                        callBack.AnnouncementStatusChanged(announcementDTO);

                        Console.WriteLine("---{0} İstasyonuna {1} Anons Tipi İçin {2} Durumu İçin Clienta Gönderildi.---", announcementDTO.stationName.ToString(), announcementDTO.announcementType.ToString(), announcementDTO.status.ToString());
                        Debug.WriteLine("---{0} İstasyonuna {1} Anons Tipi İçin {2} Durumu İçin Clienta Gönderildi.---", announcementDTO.stationName.ToString(), announcementDTO.announcementType.ToString(), announcementDTO.status.ToString());
                    }
                    else
                    {
                        m_toBeDeleted.Enqueue(callBack);

                        Console.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                        Debug.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("NotifySubscribers : " + ex.ToString());
            }
        }
        public string ConvertStationNameEnumToString(Enums.StationName stationName)
        {
            string stationFilePathName = "";

            switch (stationName)
            {
                case Enums.StationName.KayaşehirMerkez:
                    {
                        stationFilePathName = "Kayaşehir Merkez";
                        break;
                    }
                case Enums.StationName.TopluKonutlar:
                    {
                        stationFilePathName = "Toplu Konutlar";
                        break;
                    }
                case Enums.StationName.ŞehirHastanesi:
                    {
                        stationFilePathName = "Şehir Hastanesi";
                        break;
                    }
                case Enums.StationName.Onurkent:
                    {
                        stationFilePathName = "Onurkent";
                        break;
                    }
                case Enums.StationName.BaşakşehirMetrokent:
                    {
                        stationFilePathName = "Başakşehir - Metrokent";
                        break;
                    }
                case Enums.StationName.BaşakKonutları:
                    {
                        stationFilePathName = "Başak Konutları";
                        break;
                    }
                case Enums.StationName.Siteler:
                    {
                        stationFilePathName = "Siteler";
                        break;
                    }
                case Enums.StationName.TurgutÖzal:
                    {
                        stationFilePathName = "Turgut Özal";
                        break;
                    }
                case Enums.StationName.İkitelliSanayi:
                    {
                        stationFilePathName = "İkitelli Sanayi";
                        break;
                    }
                case Enums.StationName.İSTOÇ:
                    {
                        stationFilePathName = "İSTOÇ";
                        break;
                    }
                case Enums.StationName.Mahmutbey:
                    {
                        stationFilePathName = "Mahmutbey";
                        break;
                    }
                case Enums.StationName.Yenimahalle:
                    {
                        stationFilePathName = "Yenimahalle";
                        break;
                    }
                case Enums.StationName.Kirazlı:
                    {
                        stationFilePathName = "Kirazlı - Bağcılar";
                        break;
                    }
                case Enums.StationName.MollaGürani:
                    {
                        stationFilePathName = "Molla Gürani";
                        break;
                    }
                case Enums.StationName.Yıldıztepe:
                    {
                        stationFilePathName = "Yıldıztepe";
                        break;
                    }
                case Enums.StationName.İlkyuva:
                    {
                        stationFilePathName = "İlkyuva";
                        break;
                    }
                case Enums.StationName.Haznedar:
                    {
                        stationFilePathName = "Haznedar";
                        break;
                    }
                case Enums.StationName.İncirli:
                    {
                        stationFilePathName = "İncirli";
                        break;
                    }
                case Enums.StationName.ÖzgürlükMeydanı:
                    {
                        stationFilePathName = "Özgürlük Meydanı";
                        break;
                    }
                case Enums.StationName.BakırköySahil:
                    {
                        stationFilePathName = "Bakırköy Sahil";
                        break;
                    }
                case Enums.StationName.Ataköy:
                    {
                        stationFilePathName = "Ataköy";
                        break;
                    }
                case Enums.StationName.Yenibosna:
                    {
                        stationFilePathName = "Yenibosna";
                        break;
                    }
                case Enums.StationName.Çobançeşme:
                    {
                        stationFilePathName = "Çobançeşme";
                        break;
                    }
                case Enums.StationName.YirmiDokuzEkimCumhuriyet:
                    {
                        stationFilePathName = "29 Ekim Cumhuriyet";
                        break;
                    }
                case Enums.StationName.DoğuSanayi:
                    {
                        stationFilePathName = "Doğu Sanayi";
                        break;
                    }
                case Enums.StationName.MimarSinan:
                    {
                        stationFilePathName = "Mimar Sinan";
                        break;
                    }
                case Enums.StationName.OnBeşTemmuz:
                    {
                        stationFilePathName = "15 Temmuz";
                        break;
                    }
                case Enums.StationName.HalkalıCaddesi:
                    {
                        stationFilePathName = "Halkalı Caddesi";
                        break;
                    }
                case Enums.StationName.AtatürkMahallesi:
                    {
                        stationFilePathName = "Atatürk Mahallesi";
                        break;
                    }
                case Enums.StationName.Bahariye:
                    {
                        stationFilePathName = "Bahariye";
                        break;
                    }

                case Enums.StationName.MASKO:
                    {
                        stationFilePathName = "Masko";
                        break;
                    }

                case Enums.StationName.ZiyaGökalpMahallesi:
                    {
                        stationFilePathName = "Ziya Gökalp Mahallesi";
                        break;
                    }
                case Enums.StationName.Olimpiyat:
                    {
                        stationFilePathName = "Olimpiyat";
                        break;
                    }
                case Enums.StationName.DepoSahası:
                    {
                        stationFilePathName = "Depo Sahası";
                        break;
                    }
            }

            return stationFilePathName;
        }

        public string LearnMPUStatus(string MPUName)
        {
            string durum = "Undefined";

            if (MPUName == "MPU")
                durum = MpuStatus;
            else if(MPUName == "MPU_RED")
                durum = MpuRedStatus;

            return durum;
        }


        public Enums.StationName ConvertStationNameStringToEnum(string stationName)
        {
            Enums.StationName stationNameEnum = Enums.StationName.NA;

            switch (stationName)
            {
                case "Kayaşehir Merkez":
                    {
                        stationNameEnum = Enums.StationName.KayaşehirMerkez;
                        break;
                    }
                case "Toplu Konutlar":
                    {
                        stationNameEnum = Enums.StationName.TopluKonutlar;
                        break;
                    }
                case "Şehir Hastanesi":
                    {
                        stationNameEnum = Enums.StationName.ŞehirHastanesi;
                        break;
                    }
                case "Onurkent":
                    {
                        stationNameEnum = Enums.StationName.Onurkent;
                        break;
                    }
                case "Başakşehir - Metrokent":
                    {
                        stationNameEnum = Enums.StationName.BaşakşehirMetrokent;
                        break;
                    }
                case "Başak Konutları":
                    {
                        stationNameEnum = Enums.StationName.BaşakKonutları;
                        break;
                    }
                case "Siteler":
                    {
                        stationNameEnum = Enums.StationName.Siteler;
                        break;
                    }
                case "Turgut Özal":
                    {
                        stationNameEnum = Enums.StationName.TurgutÖzal;
                        break;
                    }
                case "İkitelli Sanayi":
                    {
                        stationNameEnum = Enums.StationName.İkitelliSanayi;
                        break;
                    }
                case "İSTOÇ":
                    {
                        stationNameEnum = Enums.StationName.İSTOÇ;
                        break;
                    }
                case "Mahmutbey":
                    {
                        stationNameEnum = Enums.StationName.Mahmutbey;
                        break;
                    }
                case "Yenimahalle":
                    {
                        stationNameEnum = Enums.StationName.Yenimahalle;
                        break;
                    }
                case "Kirazlı - Bağcılar":
                    {
                        stationNameEnum = Enums.StationName.Kirazlı;
                        break;
                    }
                case "Molla Gürani":
                    {
                        stationNameEnum = Enums.StationName.MollaGürani;
                        break;
                    }
                case "Yıldıztepe":
                    {
                        stationNameEnum = Enums.StationName.Yıldıztepe;
                        break;
                    }
                case "İlkyuva":
                    {
                        stationNameEnum = Enums.StationName.İlkyuva;
                        break;
                    }
                case "Haznedar":
                    {
                        stationNameEnum = Enums.StationName.Haznedar;
                        break;
                    }
                case "İncirli":
                    {
                        stationNameEnum = Enums.StationName.İncirli;
                        break;
                    }
                case "Özgürlük Meydanı":
                    {
                        stationNameEnum = Enums.StationName.ÖzgürlükMeydanı;
                        break;
                    }
                case "Bakırköy Sahil":
                    {
                        stationNameEnum = Enums.StationName.BakırköySahil;
                        break;
                    }
                case "Ataköy":
                    {
                        stationNameEnum = Enums.StationName.Ataköy;
                        break;
                    }
                case "Yenibosna":
                    {
                        stationNameEnum = Enums.StationName.Yenibosna;
                        break;
                    }
                case "Çobançeşme":
                    {
                        stationNameEnum = Enums.StationName.Çobançeşme;
                        break;
                    }
                case "29 Ekim Cumhuriyet":
                    {
                        stationNameEnum = Enums.StationName.YirmiDokuzEkimCumhuriyet;
                        break;
                    }
                case "Doğu Sanayi":
                    {
                        stationNameEnum = Enums.StationName.DoğuSanayi;
                        break;
                    }
                case "Mimar Sinan":
                    {
                        stationNameEnum = Enums.StationName.MimarSinan;
                        break;
                    }
                case "15 Temmuz":
                    {
                        stationNameEnum = Enums.StationName.OnBeşTemmuz;
                        break;
                    }
                case "Halkalı Caddesi":
                    {
                        stationNameEnum = Enums.StationName.HalkalıCaddesi;
                        break;
                    }
                case "Atatürk Mahallesi":
                    {
                        stationNameEnum = Enums.StationName.AtatürkMahallesi;
                        break;
                    }
                case "Bahariye":
                    {
                        stationNameEnum = Enums.StationName.Bahariye;
                        break;
                    }

                case "Masko":
                    {
                        stationNameEnum = Enums.StationName.MASKO;
                        break;
                    }

                case "Ziya Gökalp Mahallesi":
                    {
                        stationNameEnum = Enums.StationName.ZiyaGökalpMahallesi;
                        break;
                    }
                case "Olimpiyat":
                    {
                        stationNameEnum = Enums.StationName.Olimpiyat;
                        break;
                    }
                case "Depo Sahası":
                    {
                        stationNameEnum = Enums.StationName.DepoSahası;
                        break;
                    }
            }

            return stationNameEnum;
        }

        public void SetMasterVolume(int newLevel)
        {
            try
            {
                foreach (ICallbackMPUStatus callBack in m_notifySubscribers)
                {
                    if (((ICommunicationObject)callBack).State == CommunicationState.Opened)
                    {
                        callBack.VolumeStatusChanged(newLevel);
                    }
                    else
                    {
                        m_toBeDeleted.Enqueue(callBack);

                        Console.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                        Debug.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetMasterVolume : " + ex.ToString());
            } 
        }

        public int GetMasterVolume()
        {
            int result = 0;

            try
            {  
                float volume = AudioManager.GetMasterVolume();
                result = Convert.ToInt32(volume); 

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetMasterVolume : " + ex.ToString());
                return result;
            } 
        }

        public void SetMasterVolumeMute(bool mute)
        {
            try
            {
                foreach (ICallbackMPUStatus callBack in m_notifySubscribers)
                {
                    if (((ICommunicationObject)callBack).State == CommunicationState.Opened)
                    {
                        callBack.VolumeMuteStatusChanged(mute);
                    }
                    else
                    {
                        m_toBeDeleted.Enqueue(callBack);

                        Console.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                        Debug.WriteLine("Silinecek İstemciler Listesine İstemci Eklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetMasterVolumeMute : " + ex.ToString());
            }

        }

        public bool GetMasterVolumeMute()
        {
            bool mute=false;

            try
            {
                mute = AudioManager.GetMasterVolumeMute();

                return mute; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetMasterVolumeMute : " + ex.ToString());
                return mute;
            }

        }
    }
}
