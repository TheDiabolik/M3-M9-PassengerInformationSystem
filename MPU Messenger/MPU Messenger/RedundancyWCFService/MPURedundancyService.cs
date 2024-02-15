using MPUMessenger.MPUService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPUMessenger
{
    public class MPURedundancyService : MPUService.IM3YBSCommunicationCallback, IDisposable
    {
        public void A1VehicleDoorStatusChanged(bool A1VehicleDoorStatus)
        {
            Debug.WriteLine("A1VehicleDoorStatusChanged : " + A1VehicleDoorStatus.ToString());
        }

        public void A2VehicleDoorStatusChanged(bool A2VehicleDoorStatus)
        {
            Debug.WriteLine("A2VehicleDoorStatusChanged : " + A2VehicleDoorStatus.ToString());
        }

        public void B1VehicleDoorStatusChanged(bool B1VehicleDoorStatus)
        {
            Debug.WriteLine("B1VehicleDoorStatusChanged : " + B1VehicleDoorStatus.ToString());
        }

        public void C1VehicleDoorStatusChanged(bool C1VehicleDoorStatus)
        {
            Debug.WriteLine("C1VehicleDoorStatusChanged : " + C1VehicleDoorStatus.ToString());
        }

        public void DD_CMileageKm_1Changed(int DD_CMileageKm_1)
        {
            Debug.WriteLine("DD_CMileageKm_1Changed : " + DD_CMileageKm_1.ToString());
        }

        public void EVR_CResetDistChanged(bool EVR_CResetDist)
        {
            //Debug.WriteLine("Manuel EVR_CResetDist Reset Talebi.");

            //DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, "Manuel EVR_CResetDist Reset Talebi.");

            ////MainForm.m_mf.m_MPUToClientProperties.EVR_ICountDist = 0;


            //MainForm.m_mf.m_settings = MainForm.m_mf.m_settings.DeSerialize(MainForm.m_mf.m_settings);

            //if (MainForm.m_mf.m_settings.CommunicationType == Enums.Communication.MPU)
            //    ThreadPool.QueueUserWorkItem(new WaitCallback(MPUOperations.ResetAhmetDistanceCounter), EVR_CResetDist);
            //else
            //{
            //    Debug.WriteLine("Manuel EVR_CResetDist Reset Talebi.");

            //    DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, "Manuel EVR_CResetDist Reset Talebi MPU_RED Üzerinde Gerçekleştirilemez!.");
            //}

            
        }

        public void EVR_ICountDistChanged(int EVR_ICountDist)
        {
            Debug.WriteLine("EVR_ICountDistChanged : " + EVR_ICountDist.ToString());
        }

        public void MPUConnectionStatusChanged(MPUService.EnumsCommunication communication, MPUService.EnumsConnection connection)
        {
            Debug.WriteLine("MPU Bağlantı Durumunda Değişiklik Oldu." + " " + communication.ToString() + " " + connection.ToString());

            DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, "MPU Bağlantı Durumunda Değişiklik Oldu." + " " + communication.ToString() + " " + connection.ToString());
        }

        public void VB_DRS_OpenDoorsLeftChanged(bool VB_DRS_OpenDoorsLeft)
        {
            Debug.WriteLine("VB_DRS_OpenDoorsLeftChanged : " + VB_DRS_OpenDoorsLeft.ToString());
        }

        public void VB_DRS_OpenDoorsRightChanged(bool VB_DRS_OpenDoorsRight)
        {
            Debug.WriteLine("VB_DRS_OpenDoorsRightChanged : " + VB_DRS_OpenDoorsRight.ToString());
        }

        public void VB_DRS_TLLeftDrsReleasedChanged(bool VB_DRS_TLLeftDrsReleased)
        {
            Debug.WriteLine("VB_DRS_TLLeftDrsReleasedChanged : " + VB_DRS_TLLeftDrsReleased.ToString());
        }

        public void VB_DRS_TLRightDrsReleasedChanged(bool VB_DRS_TLRightDrsReleased)
        {
            Debug.WriteLine("VB_DRS_TLRightDrsReleasedChanged : " + VB_DRS_TLRightDrsReleased.ToString());
        }

        public void VI_TBS_TrainSpeedKphChanged(int VI_TBS_TrainSpeedKph)
        {
            Debug.WriteLine("VI_TBS_TrainSpeedKphChanged : " + VI_TBS_TrainSpeedKph.ToString());
        }

        public void Dispose()
        {
            MainForm.m_mf.m_client.Close();
        }

        public void NotifyMasterMPUForResetEVRDistanceStatus(string masterMPU, bool EVR_ICountDist)
        {
            MainForm.m_mf.m_settings = MainForm.m_mf.m_settings.DeSerialize(MainForm.m_mf.m_settings);

            if (MainForm.m_mf.m_settings.CommunicationType == Enums.Communication.MPU)
            {
                Debug.WriteLine("MPU  : " + " " + Enums.Communication.MPU.ToString() + " Distance Counter İçin Gelen Talep : " + EVR_ICountDist.ToString());

                DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, "MPU Master : " + " " + Enums.Communication.MPU.ToString() + " Distance Counter İçin Gelen Talep : " + EVR_ICountDist.ToString());
                
                ThreadPool.QueueUserWorkItem(new WaitCallback(MPUOperations.ResetDistanceCounter), EVR_ICountDist);

            }
            else
            {
                Debug.WriteLine("EVR_CResetDist Reset Talebi MPU_RED Üzerinde Gerçekleştirilemez!.");

                DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, "EVR_CResetDist Reset Talebi MPU_RED Üzerinde Gerçekleştirilemez!.");
            }
        }

        public void AnnouncementStatusChanged(MPUService.AnnouncementDTO announcementDTO)
        {
          
        }

        public void MPUBehaviorChanged(MPUService.EnumsCommunication communication, MPUService.EnumsMPUType MPUType, string masterMPUName)
        {
            Enums.Communication connectedMPU = MainForm.m_mf.m_settings.CommunicationType;

            if (communication.ToString() == connectedMPU.ToString())
            {
                DisplayManager.ToolStripStatusLabelInvoke(MainForm.m_mf.m_toolStripStatusLabelMPUBehavior, MPUType.ToString()); 
            }
            else if(connectedMPU.ToString() != masterMPUName)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(MPUOperations.ManageRedundancy), masterMPUName);
            }
        }
        
        public void MPURedundancyStateChanged(int redundancyState, string MPUName)
        {
            string MPURedundancyStatus = MainForm.m_mf.m_toolStripStatusLabelMPUBehavior.Text;
            System.Drawing.Color color = System.Drawing.SystemColors.Control;  

            MainForm.m_mf.m_settings = MainForm.m_mf.m_settings.DeSerialize(MainForm.m_mf.m_settings);

            if (redundancyState == 1)
            {
                if (MPURedundancy.Singleton().MPUCommunicationStatus)
                {
                    if ((MainForm.m_mf.m_settings.CommunicationType.ToString() == MPUName))
                        MPURedundancyStatus = "Master";
                    else if ((MainForm.m_mf.m_settings.CommunicationType.ToString() != MPUName))
                        MPURedundancyStatus = "Slave";
                }
            }
            else if (redundancyState == 2)
            {
                if (MPURedundancy.Singleton().MPUCommunicationStatus)
                {
                    if ((MainForm.m_mf.m_settings.CommunicationType.ToString() == MPUName))
                        MPURedundancyStatus = "Slave";
                    else if ((MainForm.m_mf.m_settings.CommunicationType.ToString() != MPUName))
                        MPURedundancyStatus = "Master";
                }
            }
          
            if (MPURedundancyStatus == "Master")
                color = System.Drawing.Color.Turquoise;
            else if (MPURedundancyStatus == "Slave")
                color = System.Drawing.Color.Yellow;

            DisplayManager.ToolStripStatusLabelInvoke(MainForm.m_mf.m_toolStripStatusLabelMPUBehavior, MPURedundancyStatus, color);
        }

        public void VolumeStatusChanged(int volume)
        {
            Debug.WriteLine("VolumeStatusChanged : " + volume.ToString());
        }

        public void VolumeMuteStatusChanged(bool mute)
        {
            Debug.WriteLine("VolumeMuteStatusChanged : " + mute.ToString());
        }
    }
}
