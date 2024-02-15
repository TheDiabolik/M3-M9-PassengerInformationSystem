using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnnounceMaker
{
    internal class AnnounceHelper
    {
        public static int FindWavFileLongAsAMilliSeconds(string wavFilePath)
        {
            int wavFileLong = 0;

            try
            {
                using (WaveFileReader waveReader = new WaveFileReader(wavFilePath))
                {
                    TimeSpan duration = waveReader.TotalTime;

                    wavFileLong = Convert.ToInt32(duration.TotalMilliseconds);
                }

                return wavFileLong;
            }
            catch (Exception ex)
            {
                return wavFileLong;
            }
        }

        public static void PlayWavFile()
        {
            MainForm.m_mf.soundPlayer.SoundLocation = MainForm.m_mf.m_announceFilePath;

            if (MainForm.m_mf.m_announceDTO.status == MPUService.EnumsAnnouncement.Play)
            {
                if (MainForm.m_mf.m_settings.PlaySync)
                    MainForm.m_mf.soundPlayer.PlaySync();
                else
                    MainForm.m_mf.soundPlayer.Play();
            }
            else
            {
                MainForm.m_mf.soundPlayer.Stop();
            }
        }

        public static void PrepareAnnounceFilePath(object o)
        { 
            if (MainForm.m_mf.m_amplifier == "M")
            {
                DisplayManager.RichTextBoxInvokeWithLine(MainForm.m_mf.m_richTextBox, "Anons Talebi Geldi; Kanal Meşgul 5 sn Bekleniyor...");

                Thread.Sleep(5000);

                if (MainForm.m_mf.m_amplifier != "H")
                {
                    DisplayManager.RichTextBoxInvokeWithLine(MainForm.m_mf.m_richTextBox, "Kanal Halen Meşgul Anons Talebi İptal Edildi.");
                   
                    goto GO;
                }   
            } 

            MPUService.AnnouncementDTO announceDTO = (MPUService.AnnouncementDTO)o;

            MainForm.m_mf.m_announceDTO = announceDTO;

            string stationNamePath = MainForm.m_mf.m_client.ConvertStationNameEnumToString(announceDTO.stationName);
            string announcementName = FindAnnouncementName(announceDTO.announcementType);

            if ((announceDTO.announcementType == MPUService.EnumsAnnouncementType.Station) || (announceDTO.announcementType == MPUService.EnumsAnnouncementType.Approach) ||
                (announceDTO.announcementType == MPUService.EnumsAnnouncementType.Interchange) || (announceDTO.announcementType == MPUService.EnumsAnnouncementType.Target))
            {
                if (announceDTO.metroLines == MPUService.EnumsMetroLines.M3)
                    MainForm.m_mf.m_announceFilePath = MainForm.m_mf.m_settings.M3StationAnnouncementFilePath + "\\" + stationNamePath + "\\" + announcementName;
                else if (announceDTO.metroLines == MPUService.EnumsMetroLines.M9)
                    MainForm.m_mf.m_announceFilePath = MainForm.m_mf.m_settings.M9StationAnnouncementFilePath + "\\" + stationNamePath + "\\" + announcementName;
                else
                    MainForm.m_mf.m_announceFilePath = MainForm.m_mf.m_settings.M9StationAnnouncementFilePath + "\\" + stationNamePath + "\\" + announcementName;
            }
            else if ((announceDTO.announcementType == MPUService.EnumsAnnouncementType.Special))
            {
                if (announceDTO.metroLines == MPUService.EnumsMetroLines.M3)
                    MainForm.m_mf.m_announceFilePath = MainForm.m_mf.m_settings.M3PrivateAnnouncementFilePath + "\\" + announceDTO.privateAnnouncementFileName;
                else if (announceDTO.metroLines == MPUService.EnumsMetroLines.M9)
                    MainForm.m_mf.m_announceFilePath = MainForm.m_mf.m_settings.M9PrivateAnnouncementFilePath + "\\" + announceDTO.privateAnnouncementFileName;
                else
                    MainForm.m_mf.m_announceFilePath = MainForm.m_mf.m_settings.M9PrivateAnnouncementFilePath + "\\" + announceDTO.privateAnnouncementFileName;
            }
            else
            {
                //başlangıç anonsları
                MainForm.m_mf.m_announceFilePath = announceDTO.privateAnnouncementFileName;

                if (announceDTO.metroLines == MPUService.EnumsMetroLines.M3)
                    MainForm.m_mf.m_announceFilePath = MainForm.m_mf.m_settings.M3StationAnnouncementFilePath + "\\" + stationNamePath + "\\" + MainForm.m_mf.m_announceFilePath;
                else
                    MainForm.m_mf.m_announceFilePath = MainForm.m_mf.m_settings.M9StationAnnouncementFilePath + "\\" + stationNamePath + "\\" + MainForm.m_mf.m_announceFilePath;
            }

            DisplayManager.RichTextBoxInvokeWithLine(MainForm.m_mf.m_richTextBox, "Anfiye Seri Porttan Kanal Açma Talebi Gönderiliyor.");

            if(MainForm.m_mf.m_serialPort.IsOpen)
                MainForm.m_mf.m_serialPort.Write("1");

        GO: Console.Write("");
        }


        public static string FindAnnouncementName(MPUService.EnumsAnnouncementType announcementType)
        {
            string announcementName = "";

            switch (announcementType)
            {
                case MPUService.EnumsAnnouncementType.Approach:
                    {
                        announcementName = "yaklasim.wav";
                        break;
                    }
                case MPUService.EnumsAnnouncementType.Station:
                    {
                        announcementName = "istasyon.wav";
                        break;
                    }
                case MPUService.EnumsAnnouncementType.Interchange:
                    {
                        announcementName = "aktarma.wav";
                        break;
                    }
                case MPUService.EnumsAnnouncementType.Target:
                    {
                        announcementName = "terminal.wav";
                        break;
                    }
            }
            return announcementName;
        }
        public static void PlayInsideAnnounce()
        {
            if (!MainForm.m_mf.m_test)
            {  
                if (MainForm.m_mf.m_amplifier == "H")
                {
                    if (MainForm.m_mf.m_timer.Enabled)
                        MainForm.m_mf.m_timer.Stop();

                    AnnounceHelper.PlayWavFile();

                    int wavFileLongAsAMilliSeconds = AnnounceHelper.FindWavFileLongAsAMilliSeconds(MainForm.m_mf.m_announceFilePath);


                    DisplayManager.RichTextBoxInvokeWithLine(MainForm.m_mf.m_richTextBox, "Anons Çalınıyor; " + (wavFileLongAsAMilliSeconds / 1000).ToString() + 
                        " Saniye Sonra Kanal Kapatma Talebi Gönderilecek!"); 


                    MainForm.m_mf.m_timer.Interval = (wavFileLongAsAMilliSeconds + 1000);

                    if (!MainForm.m_mf.m_timer.Enabled)
                        MainForm.m_mf.m_timer.Start(); ;
                } 
            }
        } 

        public static void CloseChannelUI()
        {
            if (!MainForm.m_mf.m_test)
                DisplayManager.RichTextBoxInvokeWithLine(MainForm.m_mf.m_richTextBox, "Kanal Kapatma Tamamlandı!");
        }

        public static void SendCloseChannelRequestUI()
        {
            DisplayManager.RichTextBoxInvokeWithLine(MainForm.m_mf.m_richTextBox, "Kanal Kapatma Talebi Gönderildi!");
        }

    }
}
