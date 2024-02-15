using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnounceMaker
{
    internal class SerialPortHelper
    { 
        public static void SendCommandToSerialPort(string command)
        {
            if (MainForm.m_mf.m_serialPort.IsOpen)
            {
                MainForm.m_mf.m_serialPort.Write(command);

                MainForm.m_mf.m_serialPort.DiscardInBuffer();
                MainForm.m_mf.m_serialPort.DiscardOutBuffer();
            } 
        }  

        public static void ParseSerialPort(string stringToParse)
        {
            switch (stringToParse)
            {
                case "icacik":
                    {
                        AnnounceHelper.PlayInsideAnnounce();
                        break;
                    }
                case "disacik":
                    {

                        break;
                    }
                case "ickapali":
                    {
                        AnnounceHelper.CloseChannelUI();
                        break;
                    }
                case "diskapali":
                    {
                        AnnounceHelper.CloseChannelUI();
                        break;
                    }
                case "hepsiacik":
                    {

                        break;

                    }
                case "hepsikapali":
                    {
                        AnnounceHelper.CloseChannelUI();

                        break;

                    }
                case "mesgul":
                    {
                        MainForm.m_mf.m_amplifier = "M";
                        break;

                    }
                case "hazir":
                    {
                        MainForm.m_mf.m_amplifier = "H";
                        break;

                    }
            }

        }
    }
}
