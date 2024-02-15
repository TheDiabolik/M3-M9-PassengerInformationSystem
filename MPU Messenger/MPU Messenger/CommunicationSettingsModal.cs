using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPUMessenger
{
    public partial class CommunicationSettingsModal : Form
    {
        private MainForm m_mf;
        XMLSerialization m_settings;
        public CommunicationSettingsModal()
        {
            InitializeComponent();

            //ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);

            //ayarları atama
            m_textBoxMPUMessageTimeout.Text = m_settings.MPUTimeout.ToString();

            if (m_settings.CommunicationType == Enums.Communication.MPU)
                m_radioButtonMPU.Checked = true;
            else
                m_radioButtonClient.Checked = true;

            if(m_settings.WorkType == Enums.WorkType.Single)
                m_radioButtonSingle.Checked = true;
            else
                m_radioButtonRedundant.Checked = true;

            if (m_settings.WriteLog)
                m_checkBoxLogWrite.Checked = true;
            else
                m_checkBoxLogWrite.Checked = false;

            if (m_settings.ShowVehicleStatus)
                m_checkBoxVehicleInfo.Checked = true;
            else
                m_checkBoxVehicleInfo.Checked = false;

            if (m_settings.ShowRedundancyServiceCommunication)
                m_checkBoxRedundancyStatus.Checked = true;
            else
                m_checkBoxRedundancyStatus.Checked = false;

            if (m_settings.ConnectMPU)
                m_checkBoxConnectMPU.Checked = true;
            else
                m_checkBoxConnectMPU.Checked = false;

        }
        public CommunicationSettingsModal(MainForm mf) : this()
        {
            m_mf = mf;
        }
        private void CommunicationSettingsModal_Load(object sender, EventArgs e)
        {

        }

        private void m_buttonSave_Click(object sender, EventArgs e)
        {
            m_settings.WriteLog = m_checkBoxLogWrite.Checked; 
            m_settings.ShowRedundancyServiceCommunication = m_checkBoxRedundancyStatus.Checked;
            m_settings.ShowVehicleStatus = m_checkBoxVehicleInfo.Checked;
            m_settings.ConnectMPU = m_checkBoxConnectMPU.Checked;

            m_settings.MPUTimeout = Convert.ToInt32(m_textBoxMPUMessageTimeout.Text);

            if (m_radioButtonMPU.Checked)
                m_settings.CommunicationType = Enums.Communication.MPU;
            else
                m_settings.CommunicationType = Enums.Communication.MPU_RED;

            if (m_radioButtonSingle.Checked)
                m_settings.WorkType = Enums.WorkType.Single;
            else
                m_settings.WorkType = Enums.WorkType.Redundant;

            //mpu bağlantısını durdumak için
            if(m_settings.CommunicationType.ToString() != MainForm.m_mf.m_toolStripStatusLabelMPUName.Text)
            {
                if(MainForm.m_mf.m_backgroundWorkerTimerAddVariables.Enabled)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        MainForm.m_mf.m_backgroundWorkerTimerAddVariables.Enabled = false; 
                    })); 
                } 

                if (MainForm.m_mf.m_backgroundWorkerTimerAddTraceDefinition.Enabled) 
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        MainForm.m_mf.m_backgroundWorkerTimerAddTraceDefinition.Enabled = false;
                    }));
                } 

                if (MainForm.m_mf.m_backgroundWorkerTimerGetVariablesInformation.Enabled)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        MainForm.m_mf.m_backgroundWorkerTimerGetVariablesInformation.Enabled = false;
                    })); 
                }

                DisplayManager.ToolStripStatusLabelInvoke(MainForm.m_mf.m_toolStripStatusLabelMPUName, MainForm.m_mf.m_toolStripStatusLabelMPUName.Text, Color.Red);
            }  

            m_settings.Serialize(m_settings);
            m_settings = m_settings.DeSerialize(m_settings); 

            if (m_settings.WorkType == Enums.WorkType.Single)
            {
                MainForm.m_mf.StopMPUServiceClient();
                
                DisplayManager.ToolStripStatusLabelInvoke(MainForm.m_mf.m_toolStripStatusLabelWorkStatus, "Tekil", SystemColors.Control);
            }
                
            else
            {
                MainForm.m_mf.StopMPUServiceClient();
                MainForm.m_mf.StartMPUServiceClient(m_settings.CommunicationType);

                if (!MainForm.m_mf.m_timerCheckMPURedundancyServiceConnectionStatus.Enabled)
                    MainForm.m_mf.m_timerCheckMPURedundancyServiceConnectionStatus.Start();

                MainForm.m_mf.m_stopWatchRedundancyService.Restart();
            }

            //ayarları kaydettikten sonra mpu bağlantısını tekrar başlatmak için
            if (m_settings.CommunicationType.ToString() != MainForm.m_mf.m_toolStripStatusLabelMPUName.Text)
            {
                if (!MainForm.m_mf.m_backgroundWorkerTimerAddVariables.Enabled)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        MainForm.m_mf.m_backgroundWorkerTimerAddVariables.Enabled = true;
                    }));
                }

                DisplayManager.ToolStripStatusLabelInvoke(MainForm.m_mf.m_toolStripStatusLabelMPUName, m_settings.CommunicationType.ToString(), Color.Red);
            }

            if ((Button)sender == m_buttonApply)
                this.Close();
        }
    }
}
