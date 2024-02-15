using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnounceMaker
{
    public partial class SerialPortModal : Form
    {
        private MainForm m_mf;
        XMLSerialization m_settings;

        public SerialPortModal()
        {
            InitializeComponent();

            //ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);


            try
            {
                foreach (string i in SerialPort.GetPortNames())
                {
                    m_comboBoxPortName.Items.Add(i);
                }
            }
            catch
            {
                MessageBox.Show("Seri Portlar Yüklemenedi !?");
            }

            m_comboBoxPortName.Text = m_settings.PortName;
            m_comboBoxBaudRate.Text = m_settings.BaudRate.ToString();
            m_comboBoxDataBits.Text = m_settings.DataBits;

            switch (m_settings.Parity)
            {
                case (Parity.None):
                    {
                        m_comboBoxParity.SelectedIndex = 0;
                    }
                    break;
                case (Parity.Odd):
                    {
                        m_comboBoxParity.SelectedIndex = 1;
                    }
                    break;
                case (Parity.Even):
                    {
                        m_comboBoxParity.SelectedIndex = 2;
                    }
                    break;
                case (Parity.Mark):
                    {
                        m_comboBoxParity.SelectedIndex = 3;
                    }
                    break;
                case (Parity.Space):
                    {
                        m_comboBoxParity.SelectedIndex = 4;
                    }
                    break;
            }

            switch (m_settings.StopBits)
            {
                case (StopBits.None):
                    {
                        m_comboBoxStopBits.SelectedIndex = 0;
                    }
                    break;
                case (StopBits.One):
                    {
                        m_comboBoxStopBits.SelectedIndex = 1;
                    }
                    break;
                case (StopBits.OnePointFive):
                    {
                        m_comboBoxStopBits.SelectedIndex = 2;
                    }
                    break;
                case (StopBits.Two):
                    {
                        m_comboBoxStopBits.SelectedIndex = 3;
                    }
                    break;
            }
        }

        private void SerialPortModal_Load(object sender, EventArgs e)
        {

        }

        private void m_buttonSave_Click(object sender, EventArgs e)
        {


            m_settings.PortName = m_comboBoxPortName.Text;
            m_settings.BaudRate = int.Parse(m_comboBoxBaudRate.Text);
            m_settings.DataBits = m_comboBoxDataBits.Text;

            switch (m_comboBoxParity.SelectedIndex)
            {
                case (0):
                    {
                        m_settings.Parity = Parity.None;
                    }
                    break;
                case (1):
                    {
                        m_settings.Parity = Parity.Odd;
                    }
                    break;
                case (2):
                    {
                        m_settings.Parity = Parity.Even;
                    }
                    break;
                case (3):
                    {
                        m_settings.Parity = Parity.Mark;
                    }
                    break;
                case (4):
                    {
                        m_settings.Parity = Parity.Space;
                    }
                    break;
            }

            switch (m_comboBoxStopBits.SelectedIndex)
            {
                case (0):
                    {
                        m_settings.StopBits = StopBits.None;
                    }
                    break;
                case (1):
                    {
                        m_settings.StopBits = StopBits.One;
                    }
                    break;
                case (2):
                    {
                        m_settings.StopBits = StopBits.OnePointFive;
                    }
                    break;
                case (3):
                    {
                        m_settings.StopBits = StopBits.Two;
                    }
                    break;
            }

            m_settings.Serialize(m_settings);
            m_settings = m_settings.DeSerialize(m_settings);


            //MainForm.m_mf.CloseSerialPort();


            SerialPortDTO serialPortDTO = new SerialPortDTO();

            serialPortDTO.portName = m_settings.PortName;
            serialPortDTO.baudRate = m_settings.BaudRate;
            serialPortDTO.dataBits = int.Parse(m_settings.DataBits);
            serialPortDTO.parity = m_settings.Parity;
            serialPortDTO.stopBits = m_settings.StopBits;

            MainForm.m_mf.SerialPortManager(serialPortDTO);









            if ((Button)sender == m_buttonApply)
                this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
