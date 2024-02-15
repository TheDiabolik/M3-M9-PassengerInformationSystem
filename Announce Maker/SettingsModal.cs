using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnounceMaker
{
    public partial class SettingsModal : Form
    {
        private MainForm m_mf;
        XMLSerialization m_settings;

        public SettingsModal()
        {
            InitializeComponent();

            //ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);

            m_textBoxM3StationFilePath.Text = m_settings.M3StationAnnouncementFilePath;
            m_textBoxM3PrivateFilePath.Text = m_settings.M3PrivateAnnouncementFilePath;
            m_textBoxM9StationFilePath.Text = m_settings.M9StationAnnouncementFilePath;
            m_textBoxM9PrivateFilePath.Text = m_settings.M9PrivateAnnouncementFilePath;

            m_checkBoxLogWrite.Checked = m_settings.SaveLog;
            m_checkBoxConnectRedundancyService.Checked = m_settings.ConnectServiceOpenning;
            m_checkBoxRedundancyStatus.Checked = m_settings.ShowServiceInfoUI; 

            if (m_settings.PlaySync)
                m_radioButtonSyncAnnouncement.Checked = true;
            else
                m_radioButtonAsyncAnnouncement.Checked = true;
        }
        public SettingsModal(MainForm mf) : this()
        {
            m_mf = mf;
        } 

        private void SettingsModal_Load(object sender, EventArgs e)
        {

        } 
        private void m_buttonSave_Click(object sender, EventArgs e)
        {

            m_settings.M3StationAnnouncementFilePath = m_textBoxM3StationFilePath.Text;
            m_settings.M3PrivateAnnouncementFilePath = m_textBoxM3PrivateFilePath.Text;

            m_settings.M9StationAnnouncementFilePath = m_textBoxM9StationFilePath.Text;
            m_settings.M9PrivateAnnouncementFilePath = m_textBoxM9PrivateFilePath.Text;


            m_settings.SaveLog = m_checkBoxLogWrite.Checked;
            m_settings.ConnectServiceOpenning = m_checkBoxConnectRedundancyService.Checked;
            m_settings.ShowServiceInfoUI = m_checkBoxRedundancyStatus.Checked;

            if (m_radioButtonSyncAnnouncement.Checked)
            {
                m_settings.PlaySync = true;
                m_settings.PlayAsync = false;
            }
                
            else
            {
                m_settings.PlaySync = false;
                m_settings.PlayAsync = true;
            }

            m_settings.Serialize(m_settings);
            m_settings = m_settings.DeSerialize(m_settings);


            if ((Button)sender == m_buttonApply)
                this.Close();
        }
        private void m_buttonFilePath_Click(object sender, EventArgs e)
        {
            if (m_folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                m_textBoxM3StationFilePath.Text = m_folderBrowserDialog.SelectedPath;
        }
        private void m_buttonPrivateFilePath_Click(object sender, EventArgs e)
        {
            if (m_folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                m_textBoxM3PrivateFilePath.Text = m_folderBrowserDialog.SelectedPath;
        }

        private void m_buttonStationM9FilePath_Click(object sender, EventArgs e)
        {
            if (m_folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                m_textBoxM9StationFilePath.Text = m_folderBrowserDialog.SelectedPath;
        }

        private void m_buttonM9PrivateFilePath_Click(object sender, EventArgs e)
        {
            if (m_folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                m_textBoxM9PrivateFilePath.Text = m_folderBrowserDialog.SelectedPath;
        }
    }
}
