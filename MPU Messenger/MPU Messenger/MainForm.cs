using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Net.Http;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Collections.Concurrent;
using System.Net.Sockets;


namespace MPUMessenger
{
    public partial class MainForm : Form
    {
        bool m_buttonSwitch = true;

        public static MainForm m_mf;
        public XMLSerialization m_settings;

        public MPUService.M3YBSCommunicationClient m_client;
        public MPUService.MPU m_mpuServiceMPU;

        internal MPU m_MPUToClientProperties;
        internal List<GetVariablesMessage> m_oVariablesInformations;
        internal List<AddedAddedVariable> m_addedAddedVariables;

        internal System.Timers.Timer m_timerCheckMPURedundancyServiceConnectionStatus;
        public Stopwatch m_stopWatchRedundancyService;

        bool m_resetDistanceCounter;
        string m_generetedGetInformationString, m_generetedAddTraceDefinationString;

        public MainForm()
        {
            InitializeComponent();

            m_mf = this;

            DisplayManager.SetDoubleBuffered(this);
            DisplayManager.SetDoubleBuffered(m_richTextBox);

            DisplayManager.SetDoubleBuffered(m_pictureBoxA1VehicleDoor);
            DisplayManager.SetDoubleBuffered(m_pictureBoxA2VehicleDoor);
            DisplayManager.SetDoubleBuffered(m_pictureBoxB1VehicleDoor);
            DisplayManager.SetDoubleBuffered(m_pictureBoxC1VehicleDoor);

            DisplayManager.SetDoubleBuffered(m_pictureBoxTLLeftDrsReleased);
            DisplayManager.SetDoubleBuffered(m_pictureBoxTLRightDrsReleased);
            DisplayManager.SetDoubleBuffered(m_pictureBoxOpenDoorsLeft);
            DisplayManager.SetDoubleBuffered(m_pictureBoxOpenDoorsRight);

            DisplayManager.SetDoubleBuffered(m_textBoxSpeed);
            DisplayManager.SetDoubleBuffered(m_textBoxDistanceCounter);
            DisplayManager.SetDoubleBuffered(m_textBoxMileageKm);

            m_stopWatchRedundancyService = new Stopwatch();

            //ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);

            m_MPUToClientProperties = new MPU();

            m_oVariablesInformations = new List<GetVariablesMessage>();
            m_addedAddedVariables = new List<AddedAddedVariable>();

            m_timerCheckMPURedundancyServiceConnectionStatus = new System.Timers.Timer(3000);
            m_timerCheckMPURedundancyServiceConnectionStatus.Elapsed += m_timerCheckMPUConnectionStatus_Elapsed;
        }

        private async void m_timerCheckMPUConnectionStatus_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (m_settings.WorkType == Enums.WorkType.Redundant)
            {
                if (m_stopWatchRedundancyService.Elapsed.TotalSeconds > 5)
                {
                    m_timerCheckMPURedundancyServiceConnectionStatus.Stop();

                    m_stopWatchRedundancyService.Stop();
                    m_stopWatchRedundancyService.Reset();

                    if (m_settings.DeSerialize(m_settings).ShowRedundancyServiceCommunication)
                        DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.CheckRedundancyServiceMessage, Color.Red);

                    try
                    {
                        if (m_client != null)
                        {
                            MPUService.EnumsCommunication enumsCommunication;

                            if (m_settings.CommunicationType == Enums.Communication.MPU)
                                enumsCommunication = MPUService.EnumsCommunication.MPU;
                            else
                                enumsCommunication = MPUService.EnumsCommunication.MPU_RED;

                            MPUService.EnumsConnection MPUConnectionStatus;

                            if (MPURedundancy.Singleton().MPUCommunicationStatus)
                                MPUConnectionStatus = MPUService.EnumsConnection.CONNECTED;
                            else
                                MPUConnectionStatus = MPUService.EnumsConnection.NOT_CONNECTED;

                            //wcf instance null değilse veri alışverişi var mı kontrolü?
                            Task<string> heartbeatTask = m_client.HeartBeatWithConnectionCheckAsync("AREUALIVE", enumsCommunication, MPUConnectionStatus);

                            var timeoutTask = Task.Delay(1500);

                            //1,5 sn boyunca cevap gelmezse beklemeyi durdur
                            var completedTask = await Task.WhenAny(heartbeatTask, timeoutTask);

                            if (completedTask == timeoutTask)
                            {
                                await m_client.UnsubscribeAsync();

                                //wcf instanceyi nulla ve servise bağlanmayı tekrar dene?
                                m_client = null;
                                StartMPUServiceClient(m_settings.CommunicationType);
                            }
                            else if (heartbeatTask.Result != null && heartbeatTask.Result == "IMALIVE")
                            {
                                if (m_settings.DeSerialize(m_settings).ShowRedundancyServiceCommunication)
                                    DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.RespondRedundancyServiceMessage, Color.Red);
                            }
                        }
                        else //m_client null ise
                        {
                            StartMPUServiceClient(m_settings.CommunicationType);
                        }
                    }
                    catch (Exception ex)
                    {
                        m_client = null;

                        Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), ExceptionMessages.ReConnectMPURedundancyServiceExceptionMessage);

                        DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelWorkStatus, "Yedekli", Color.Red);
                    }

                    if (!m_timerCheckMPURedundancyServiceConnectionStatus.Enabled)
                        m_timerCheckMPURedundancyServiceConnectionStatus.Start();

                    m_stopWatchRedundancyService.Restart();
                }
            }
        }
        public async void StartMPUServiceClient(Enums.Communication MPUType)
        {
            try
            {
                if (m_client == null)
                {
                    if (m_settings.DeSerialize(m_settings).ShowRedundancyServiceCommunication)
                        DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.RedundancyServiceMessage, Color.Red);

                    InstanceContext context = new InstanceContext(new MPURedundancyService());

                    m_client = new MPUService.M3YBSCommunicationClient(context);

                    bool returnSubcr = await m_client.SubscribeAsync();

                    MPUService.EnumsCommunication enumsCommunication;

                    if (MPUType == Enums.Communication.MPU)
                    {
                        enumsCommunication = MPUService.EnumsCommunication.MPU;
                    }
                    else //if (MPUType == Enums.Communication.MPU_RED)
                    {
                        enumsCommunication = MPUService.EnumsCommunication.MPU_RED;
                    }

                    MPUService.EnumsMPUType enumsMPUType;

                    if (m_MPUToClientProperties.RedundancyState == 1)
                    {
                        enumsMPUType = MPUService.EnumsMPUType.Master;
                    }
                    else if (m_MPUToClientProperties.RedundancyState == 2)
                    {
                        enumsMPUType = MPUService.EnumsMPUType.Slave;
                    }
                    else //if (m_MPUToClientProperties.RedundancyState == 0)
                    {
                        enumsMPUType = MPUService.EnumsMPUType.Undefined;
                    }

                    MPUService.EnumsConnection enumsConnection;

                    if (MPURedundancy.Singleton().MPUCommunicationStatus)
                        enumsConnection = MPUService.EnumsConnection.CONNECTED;
                    else
                        enumsConnection = MPUService.EnumsConnection.CONNECTION_LOST;

                    m_mpuServiceMPU = new MPUService.MPU();
                    m_mpuServiceMPU.communication = enumsCommunication;
                    m_mpuServiceMPU.MPUType = enumsMPUType;
                    m_mpuServiceMPU.connection = enumsConnection;

                    m_mpuServiceMPU = await m_client.AddOrFindInRedundancyMPUAsync(m_mpuServiceMPU);

                    //araç zaten hareket halinde serviste son duruma göre setlemenin anlamı yok!
                    //AssignExistingMPUDataToLocalMPUStruct();
                }

                if (m_settings.DeSerialize(m_settings).ShowRedundancyServiceCommunication)
                    DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.RedundancyServiceConnectedMessage, Color.Red);

                if (m_mpuServiceMPU != null)
                    DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelWorkStatus, "Yedekli", Color.Green);

            }
            catch (Exception ex)
            {
                m_client = null;
                m_mpuServiceMPU = null;

                DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.ErrorRedundancyServiceMessage, Color.Red);

                DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelWorkStatus, "Yedekli", Color.Red);

                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), ExceptionMessages.ConnectMPURedundancyServiceExceptionMessage);
            }
        }

        public async void StopMPUServiceClient()
        {
            try
            {
                if (m_client != null)
                {
                    bool returnSubcribe = await m_client.UnsubscribeAsync();

                    m_mpuServiceMPU = null;

                    if (m_settings.DeSerialize(m_settings).ShowRedundancyServiceCommunication)
                        DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.ErrorRedundancyServiceMessage, Color.Red);

                    DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelWorkStatus, "Yedekli", Color.Red);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda referansın kapatılması ve hata yönetimi
                if (m_client != null && m_client.State == CommunicationState.Faulted)
                {
                    m_client.Abort();
                }

                DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.StopErrorRedundancyServiceMessage, Color.Red);

                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), ExceptionMessages.StopMPURedundancyServiceExceptionMessage);
            }
            finally
            {
                // Diğer durumlarda referansın kapatılması
                if (m_client != null && m_client.State != CommunicationState.Closed)
                {
                    m_client.Close();
                }
            }
        }

        public void AssignExistingMPUDataToLocalMPUStruct()
        {
            PropertyInfo[] existingMPUValuesProperties = typeof(MPU).GetProperties();
            PropertyInfo[] properties = typeof(MPUService.MPU).GetProperties();

            //servisten gelende dönüyorum
            foreach (PropertyInfo item in properties)
            {
                PropertyInfo propertyInfo = existingMPUValuesProperties.ToList().Find(x => x.Name == item.Name);

                if (propertyInfo != null)
                {
                    object serviceValue = item.GetValue(m_mpuServiceMPU);
                    string osman = item.Name;

                    PropertyInfo eskiProperty = typeof(MPU).GetProperty(propertyInfo.Name);

                    #region master/slave kontrolü
                    string MPUBehaviour = eskiProperty.Name;

                    if (MPUBehaviour == "MPUType")
                    {
                        string donus = Convert.ToString(serviceValue);
                        Enums.MPUType MPUType = Enums.MPUType.Undefined;

                        if (donus == "Master")
                            MPUType = Enums.MPUType.Master;
                        else if (donus == "Slave")
                            MPUType = Enums.MPUType.Slave;
                        else if (donus == "Undefined")
                            MPUType = Enums.MPUType.Undefined;

                        eskiProperty.SetValue(m_MPUToClientProperties, MPUType);
                    }
                    #endregion
                    else
                        eskiProperty.SetValue(m_MPUToClientProperties, serviceValue);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (m_settings.WorkType == Enums.WorkType.Redundant)
            {
                DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelWorkStatus, "Yedekli", Color.Red);

                if (m_settings.DeSerialize(m_settings).ShowRedundancyServiceCommunication)
                    DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.RedundancyMessage, Color.Red);

                StartMPUServiceClient(m_settings.CommunicationType);

                if (!m_timerCheckMPURedundancyServiceConnectionStatus.Enabled)
                    m_timerCheckMPURedundancyServiceConnectionStatus.Start();

                m_stopWatchRedundancyService.Restart();
            }
            else
            {
                DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.SingleModeMessage, Color.Red);

                DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelWorkStatus, "Tekil", SystemColors.Control);
            }

            DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelMPUName, m_settings.CommunicationType.ToString(), Color.Red);

            if (m_settings.ConnectMPU)
            {
                if (!m_backgroundWorkerTimerAddVariables.Enabled)
                    m_backgroundWorkerTimerAddVariables.Start();
            }
        }
        private void m_communicationItem_Click(object sender, EventArgs e)
        {
            CommunicationSettingsModal communicationSettingsModal = new CommunicationSettingsModal();
            communicationSettingsModal.Owner = this;
            communicationSettingsModal.ShowDialog();
        }
        private void m_aboutPopup_Click(object sender, EventArgs e)
        {
            AboutBox aboutBoxModal = new AboutBox();
            aboutBoxModal.Owner = this;
            aboutBoxModal.ShowDialog();
        }
      
        private void m_backgroundWorkerTimerAddVariables_Tick(object sender, EventArgs e)
        {
            if (!m_backgroundWorkerAddVariables.IsBusy)
                m_backgroundWorkerAddVariables.RunWorkerAsync();
        }

        private void m_backgroundWorkerTimerAddTraceDefinition_Tick(object sender, EventArgs e)
        {
            if (!m_backgroundWorkerAddTraceDefinition.IsBusy)
                m_backgroundWorkerAddTraceDefinition.RunWorkerAsync();
        }
        private void m_backgroundWorkerTimer_Tick(object sender, EventArgs e)
        {
            if (!m_backgroundWorkerGetVariablesInformation.IsBusy)
                m_backgroundWorkerGetVariablesInformation.RunWorkerAsync();
        }
        private void m_radioButtonDistanceCounterResetTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (m_radioButtonDistanceCounterResetTrue.Checked)
                m_resetDistanceCounter = true;
            else
                m_resetDistanceCounter = false;
        }
        private void m_backgroundWorkerAddVariables_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundInvokeServiceAddVariables("AddVariables.txt");

                //yukarıdaki satırı eklememin sebebi yeni oluşacak getvariablesinformatin mesajını belirlemek için
                var returnList = m_addedAddedVariables.FindAll(x => x.ActionStatus == "ACCEPTED");

                if (returnList.Count == m_addedAddedVariables.Count)
                {
                    m_backgroundWorkerTimerAddVariables.Stop();

                    m_generetedAddTraceDefinationString = XMLMessageHelper.PrepareAddTraceDefinationVariablesXML();

                    m_generetedGetInformationString = XMLMessageHelper.PrepareGetVariablesXML();
                    //bu kısma kadar addvariable işlemleri tamamlanmış ve bileşenlerin idlerini almış oluyorum
                    //tcms tarafından
                    Invoke(new MethodInvoker(delegate ()
                    {
                        //AddTraceDefinition mesajının timerini başlatıyoruz
                        m_backgroundWorkerTimerAddTraceDefinition.Start();

                    }));
                }
            }
            catch (Exception ex)
            {
                MPURedundancy.Singleton().MPUCommunicationStatus = false;

                DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, ExceptionMessages.TimerGetVariablesXML, Color.Black);

                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "m_backgroundWorkerAddVariables_DoWork");
            }
        }

        private void m_backgroundWorkerAddTraceDefinition_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundInvokeServiceAddTraceDefinationResponse(m_generetedAddTraceDefinationString);
        }

        private void m_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundInvokeServiceGetVariablesInformationResponse(m_generetedGetInformationString);
        }

        private void m_richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (m_richTextBox.Text.Length > 5000)
                m_richTextBox.ResetText();

            m_richTextBox.ScrollToCaret();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_timerCheckMPURedundancyServiceConnectionStatus.Stop();

            m_backgroundWorkerTimerGetVariablesInformation.Stop();
            m_backgroundWorkerTimerAddTraceDefinition.Stop();
            m_backgroundWorkerTimerAddVariables.Stop();

        }
        public void BackgroundInvokeServiceAddVariables(string MPUSoapFileName)
        {
            try
            {
                string serviceResult = SOAPHelper.CreateSOAPMessage(MPUSoapFileName, Enums.ReadingSoapMessageType.FilePath);

                XMLMessageHelper.AddVariablesResponseParseMessage(serviceResult);
            }
            catch (Exception ex)
            {
                DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, ExceptionMessages.AddVariablesExceptionMessage, Color.Black);

                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "BackgroundInvokeServiceAddVariables");

                throw ex;
            }
        }

        public void BackgroundInvokeServiceAddTraceDefinationResponse(string MPUSoapFileName)
        {
            try
            {
                string serviceResult = SOAPHelper.CreateSOAPMessage(MPUSoapFileName, Enums.ReadingSoapMessageType.XMLString);

                m_backgroundWorkerTimerAddTraceDefinition.Stop();

                Invoke(new MethodInvoker(delegate ()
                {
                    m_backgroundWorkerTimerGetVariablesInformation.Start();

                }));
            }
            catch (Exception ex)
            {
                MPURedundancy.Singleton().MPUCommunicationStatus = false;

                DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, ExceptionMessages.GetVariablesExceptionMessage, Color.Black);

                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "BackgroundInvokeServiceAddTraceDefinationResponse");
            }
        }
        public void BackgroundInvokeServiceGetVariablesInformationResponse(string MPUSoapFileName)
        {
            try
            {
                string serviceResult = SOAPHelper.CreateSOAPMessage(MPUSoapFileName, Enums.ReadingSoapMessageType.XMLString);

                XMLMessageHelper.GetVariablesInformationResponseParseMessage(serviceResult);

                bool showMPUCommunicationInfo = m_settings.DeSerialize(m_settings).ShowVehicleStatus;

                if (!string.IsNullOrEmpty(serviceResult))
                    UIOperation.MPUCommunicationStatus(showMPUCommunicationInfo);

            }
            catch (Exception ex)
            {
                MPURedundancy.Singleton().MPUCommunicationStatus = false;

                DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, ExceptionMessages.GetVariablesExceptionMessage, Color.Black);

                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "BackgroundInvokeServiceGetVariablesInformationResponse");
            }
        }

        private void m_buttonDistanceCounterReset_Click(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;

            AddedAddedVariable addedAddedVariable = m_addedAddedVariables.Find(x => x.SymbolicName == SymbolicNames.EVR_CResetDist);

            if (myButton == m_buttonReleaseDistanceCounterReset)
            {
                string generatedResetMessage = XMLMessageHelper.PrepareResetDistanceCounterMessage(addedAddedVariable, Enums.ForceOption.UNFORCE, m_resetDistanceCounter);

                //araç testinde bu commentler açılacak
                SOAPHelper.CreateSOAPMessage(generatedResetMessage, Enums.ReadingSoapMessageType.XMLString);

            }
            else if (myButton == m_buttonSendDistanceCounterReset)
            {
                string generatedResetMessage = XMLMessageHelper.PrepareResetDistanceCounterMessage(addedAddedVariable, Enums.ForceOption.FORCE, m_resetDistanceCounter);

                //araç testinde bu commentler açılacak
                SOAPHelper.CreateSOAPMessage(generatedResetMessage, Enums.ReadingSoapMessageType.XMLString);
            }
        }
        private void m_buttonSetVariable_Click(object sender, EventArgs e)
        {
            AddedAddedVariable addedAddedVariable = m_addedAddedVariables.Find(x => x.SymbolicName == SymbolicNames.UMC_CPreRecordMsgIdx);

            if (m_buttonSwitch)
            {
                m_buttonSwitch = false;

                m_buttonSetVariable.Text = "F";

                string generatedXML = XMLMessageHelper.PrepareAhmetMessage(addedAddedVariable, Enums.ForceOption.FORCE, 192);
                //araç üzerinde test ederken commentleri kaldır
                SOAPHelper.CreateSOAPMessage(generatedXML, Enums.ReadingSoapMessageType.XMLString);
            }
            else
            {
                m_buttonSwitch = true;

                m_buttonSetVariable.Text = "U";

                string generatedXML = XMLMessageHelper.PrepareAhmetMessage(addedAddedVariable, Enums.ForceOption.UNFORCE, 192);
                //araç üzerinde test ederken commentleri kaldır
                SOAPHelper.CreateSOAPMessage(generatedXML, Enums.ReadingSoapMessageType.XMLString);
            }
        }

      

        private void m_buttonAnnouncement_Click(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;

            AddedAddedVariable addedAddedVariable = m_addedAddedVariables.Find(x => x.SymbolicName == SymbolicNames.UMC_CPreRecordMsgCtrlVal);

            if (myButton == m_buttonPlayAnnouncement)
            {
                string generatedPlayAnnouncementMessage = XMLMessageHelper.PrepareAhmetMessage(addedAddedVariable, Enums.ForceOption.FORCE, 16);
                //araç üzerinde test ederken commentleri kaldır
                SOAPHelper.CreateSOAPMessage(generatedPlayAnnouncementMessage, Enums.ReadingSoapMessageType.XMLString);
                Thread.Sleep(200);
                generatedPlayAnnouncementMessage = XMLMessageHelper.PrepareAhmetMessage(addedAddedVariable, Enums.ForceOption.UNFORCE, 16);
                ////araç üzerinde test ederken commentleri kaldır
                SOAPHelper.CreateSOAPMessage(generatedPlayAnnouncementMessage, Enums.ReadingSoapMessageType.XMLString);
            }
            else if (myButton == m_buttonStopAnnouncement)
            {
                string generatedStopAnnouncementMessage = XMLMessageHelper.PrepareAhmetMessage(addedAddedVariable, Enums.ForceOption.FORCE, 64);
                //araç üzerinde test ederken commentleri kaldır
                SOAPHelper.CreateSOAPMessage(generatedStopAnnouncementMessage, Enums.ReadingSoapMessageType.XMLString);
                Thread.Sleep(200);
                generatedStopAnnouncementMessage = XMLMessageHelper.PrepareAhmetMessage(addedAddedVariable, Enums.ForceOption.UNFORCE, 64);
                ////araç üzerinde test ederken commentleri kaldır
                SOAPHelper.CreateSOAPMessage(generatedStopAnnouncementMessage, Enums.ReadingSoapMessageType.XMLString);
            }
        } 
    }
}
