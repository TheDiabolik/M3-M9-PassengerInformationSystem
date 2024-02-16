using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.ServiceModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using NAudio.Wave;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi; 

namespace AnnounceMaker
{
    public partial class MainForm : Form
    {
        public static MainForm m_mf;
        public XMLSerialization m_settings;

        public SoundPlayer soundPlayer;
        public MPUService.M3YBSCommunicationClient m_client;

        internal System.Timers.Timer m_timerCheckMPURedundancyServiceConnectionStatus;
        public Stopwatch m_stopWatchRedundancyService;

        public MPUService.AnnouncementDTO m_announceDTO;

        public bool m_test = false;
        public string m_announceFilePath;
        public string m_amplifier = "H";



        public MainForm()
        {
            InitializeComponent();

            m_mf = this;

            //ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);

            DisplayManager.SetDoubleBuffered(this);
            DisplayManager.SetDoubleBuffered(m_richTextBox);

            DisplayManager.SetDoubleBuffered(m_buttonFirst);
            DisplayManager.SetDoubleBuffered(m_buttonSecond);
            DisplayManager.SetDoubleBuffered(m_buttonThird);
            DisplayManager.SetDoubleBuffered(m_buttonFourth);
            DisplayManager.SetDoubleBuffered(m_buttonFifth);
            DisplayManager.SetDoubleBuffered(m_buttonSixth);
            DisplayManager.SetDoubleBuffered(m_buttonPlay);


            soundPlayer = new SoundPlayer();

            m_stopWatchRedundancyService = new Stopwatch();

            m_timerCheckMPURedundancyServiceConnectionStatus = new System.Timers.Timer(3000);
            m_timerCheckMPURedundancyServiceConnectionStatus.Elapsed += m_timerCheckMPUConnectionStatus_Elapsed;


            SerialPortDTO serialPortDTO = new SerialPortDTO();

            serialPortDTO.portName = m_settings.PortName;
            serialPortDTO.baudRate = m_settings.BaudRate;
            serialPortDTO.dataBits = int.Parse(m_settings.DataBits);
            serialPortDTO.parity = m_settings.Parity;
            serialPortDTO.stopBits = m_settings.StopBits;


            SerialPortManager(serialPortDTO);

            AudioManager.SetMasterVolumeMute(false);
            AudioManager.SetMasterVolume(100); 
        }


        #region serial port

        public void SerialPortManager(SerialPortDTO serialPortDTO)
        {
            try
            {
                bool serialPortStatus = CheckSerialPort(m_settings.PortName);

                if (serialPortStatus)
                    DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelSerialPortStatus, m_settings.PortName, Color.Red);
                else
                    DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelSerialPortStatus, "NA", Color.Red);

                bool isClose = CloseSerialPort();

                if (isClose)
                {
                    DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelSerialPortStatus, m_serialPort.PortName, Color.Red);
                    m_closeSerialPortItem.Checked = true;
                    m_openSerialPortItem.Checked = false;
                }

                m_serialPort.PortName = serialPortDTO.portName;
                m_serialPort.BaudRate = serialPortDTO.baudRate;
                m_serialPort.DataBits = serialPortDTO.dataBits;
                m_serialPort.Parity = serialPortDTO.parity;
                m_serialPort.StopBits = serialPortDTO.stopBits;

                bool isOpen = OpenSerialPort();

                if (isOpen)
                {
                    DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelSerialPortStatus, m_serialPort.PortName, Color.Green);
                    m_closeSerialPortItem.Checked = false;
                    m_openSerialPortItem.Checked = true;
                }
            }
            catch (Exception ex)
            {
            }
        }  

        public bool OpenSerialPort()
        {
            bool open = false;

            try
            {
                if (!m_serialPort.IsOpen)
                {
                    m_serialPort.Open();
                    open = true;
                }

                return open;
            }
            catch (Exception ex)
            {
                return open;
            } 
        }

        public bool CloseSerialPort()
        {
            bool close = false;

            try
            {
                if (m_serialPort.IsOpen)
                {
                    m_serialPort.Close();
                    close = true;
                }
               

                return close;
            }
            catch (Exception ex)
            {
                return close;
            }
        }


        public bool CheckSerialPort(string serialPortName)
        {
            bool serialPortStatus = false; 

            try
            {
                serialPortStatus = SerialPort.GetPortNames().ToList().Contains(serialPortName);

                return serialPortStatus;
            }
            catch(Win32Exception ex)
            {
                return serialPortStatus;
            }
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(m_settings.ConnectServiceOpenning)
            {
                StartMPUServiceClient();

                if (!m_timerCheckMPURedundancyServiceConnectionStatus.Enabled)
                    m_timerCheckMPURedundancyServiceConnectionStatus.Start();

                m_stopWatchRedundancyService.Restart(); 
            }
        }

        private void channelButtons_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            m_test = true;

            if (button == m_buttonFirst)
                SerialPortHelper.SendCommandToSerialPort("1");
            else if (button == m_buttonSecond)
                SerialPortHelper.SendCommandToSerialPort("2");
            else if (button == m_buttonThird)
                SerialPortHelper.SendCommandToSerialPort("3");
            else if (button == m_buttonFourth)
                SerialPortHelper.SendCommandToSerialPort("4");
            else if (button == m_buttonFifth)
                SerialPortHelper.SendCommandToSerialPort("5");
            else if (button == m_buttonSixth)
                SerialPortHelper.SendCommandToSerialPort("6");
        } 
        public void TestPlay()
        {
            try
            {
                soundPlayer.SoundLocation = "50-Siteler_yaklasma(Yaklasim_500_mt).wav";

            if (m_settings.PlaySync)
                soundPlayer.PlaySync();
            else
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, ex.ToString(), Color.Black);

            }
        }
       
        #region yedeklilik servisi
        public async void StartMPUServiceClient()
        {
            try
            {
                if (m_client == null)
                { 
                    InstanceContext context = new InstanceContext(new MPURedundancyService());

                    m_client = new MPUService.M3YBSCommunicationClient(context);

                    bool returnSubcr = await m_client.SubscribeAsync();  

                    if(returnSubcr)
                        DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelWorkStatus, "Bağlandı!", Color.Green);
                } 
            }
            catch (Exception ex)
            {
                m_client = null;

                DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.ErrorRedundancyServiceMessage, Color.Red);

                DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelWorkStatus, "Bağlantı Yok!", Color.Red);

                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), ExceptionMessages.ConnectMPURedundancyServiceExceptionMessage);
            }
        }

        public async void StopMPUServiceClient()
        {
            try
            {
                if (m_client != null)
                {
                    //m_timerCheckMPURedundancyServiceConnectionStatus.Stop();

                    bool returnSubcribe = await m_client.UnsubscribeAsync();

                    //m_mpuServiceMPU = null;

                    if (m_settings.DeSerialize(m_settings).ShowServiceInfoUI)
                        DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.ErrorRedundancyServiceMessage, Color.Red);

                    DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelWorkStatus, "Bağlantı Yok!", Color.Red);

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

        private async void m_timerCheckMPUConnectionStatus_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //if (m_settings.WorkType == Enums.WorkType.Redundant)
            {
                if (m_stopWatchRedundancyService.Elapsed.TotalSeconds > 5)
                {
                    m_timerCheckMPURedundancyServiceConnectionStatus.Stop();

                    m_stopWatchRedundancyService.Stop();
                    m_stopWatchRedundancyService.Reset();


                    if (m_settings.DeSerialize(m_settings).ShowServiceInfoUI)
                        DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.CheckRedundancyServiceMessage, Color.Red);

                    try
                    {
                        if (m_client != null)
                        {
                            //wcf instance null değilse veri alışverişi var mı kontrolü?
                            Task<string> heartbeatTask = m_client.HeartBeatAsync("AREUALIVE");
                            var timeoutTask = Task.Delay(1500);

                            //3 sn boyunca cevap gelmezse beklemeyi durdur
                            var completedTask = await Task.WhenAny(heartbeatTask, timeoutTask);

                            if (completedTask == timeoutTask)
                            {
                                await m_client.UnsubscribeAsync();

                                //wcf instanceyi nulla ve servise bağlanmayı tekrar dene?
                                m_client = null;
                                StartMPUServiceClient();
                            }
                            else if ((heartbeatTask.Result != null) && (heartbeatTask.Result == "IMALIVE"))
                            {
                                if (m_settings.DeSerialize(m_settings).ShowServiceInfoUI)
                                    DisplayManager.RichTextBoxWithAppendLineInvoke(m_richTextBox, UIMessages.RespondRedundancyServiceMessage, Color.Red);
                            }
                            //m_client = null;
                            //StartMPUServiceClient(m_settings.CommunicationType);
                        }
                        else //m_client null ise
                        {
                            StartMPUServiceClient();
                        } 
                    }
                    catch (Exception ex)
                    {
                        m_client = null;

                        Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), ExceptionMessages.ReConnectMPURedundancyServiceExceptionMessage);

                        DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelWorkStatus, "Bağlantı Yok!", Color.Red);
                    } 

                    if (!m_timerCheckMPURedundancyServiceConnectionStatus.Enabled)
                        m_timerCheckMPURedundancyServiceConnectionStatus.Start();

                    m_stopWatchRedundancyService.Restart();
                }
            }
        }

        #endregion
     
        private void m_richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (m_richTextBox.Text.Length > 5000)
                m_richTextBox.ResetText();

            m_richTextBox.ScrollToCaret();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_timerCheckMPURedundancyServiceConnectionStatus.Stop();
        }
        private void m_generalSettingsItem_Click(object sender, EventArgs e)
        {
            SettingsModal generalSettingsModal = new SettingsModal();
            generalSettingsModal.Owner = this;
            generalSettingsModal.ShowDialog();
        }

        private void m_communicationItem_Click(object sender, EventArgs e)
        {
            SerialPortModal serialPortModal = new SerialPortModal();
            serialPortModal.Owner = this;
            serialPortModal.ShowDialog();
        }

        private void m_openSerialPortItem_Click(object sender, EventArgs e)
        {
            bool isOpen = OpenSerialPort();

            if (isOpen)
            {
                DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelSerialPortStatus, m_serialPort.PortName, Color.Green);
                m_closeSerialPortItem.Checked = false;
                m_openSerialPortItem.Checked = true;
            }
        }
        private void m_closeSerialPortItem_Click(object sender, EventArgs e)
        {
            bool isClose = CloseSerialPort();

            if (isClose)
            {
                DisplayManager.ToolStripStatusLabelInvoke(m_toolStripStatusLabelSerialPortStatus, m_serialPort.PortName, Color.Red);
                m_closeSerialPortItem.Checked = true;
                m_openSerialPortItem.Checked = false;
            }
        }

        private void m_serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = m_serialPort.ReadLine();

            DisplayManager.RichTextBoxInvoke(m_richTextBox, data, Color.Black);

            SerialPortHelper.ParseSerialPort(data); 
        } 

        private void m_timer_Tick(object sender, EventArgs e)
        { 
            m_timer.Stop(); 

            this.Invoke(new MethodInvoker(delegate ()
            {

                if(m_serialPort.IsOpen)
                    m_serialPort.Write("6"); 
            }));

            AnnounceHelper.SendCloseChannelRequestUI();
        }

        public static void ChangeVolume(object command)
        {
            int status = (int)command;

            //DisplayManager.RichTextBoxInvokeWithLine(MainForm.m_mf.m_richTextBox, "Ses Seviyesi : " + status.ToString() + " Olarak Ayarlandı.");

            AudioManager.SetMasterVolume(status);
        }

        public static void MuteVolume(object command)
        {
            bool status = (bool)command;
            string volumeStatus;

            if (status)
                volumeStatus = "Sessize Alındı.";
            else
                volumeStatus = "Ses Açıldı.";

            DisplayManager.RichTextBoxInvokeWithLine(MainForm.m_mf.m_richTextBox, volumeStatus);

            AudioManager.SetMasterVolumeMute(status);
        }

        private void m_buttonPlay_Click(object sender, EventArgs e)
        {
            TestPlay();
        }

     

        private void m_aboutPopup_Click(object sender, EventArgs e)
        {
            AboutBox generalSettingsModal = new AboutBox();
            generalSettingsModal.Owner = this;
            generalSettingsModal.ShowDialog();
        }

        private void m_settingsPopup_Click(object sender, EventArgs e)
        {

        }

        private void seriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
