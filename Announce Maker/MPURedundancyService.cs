using AnnounceMaker.MPUService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnnounceMaker
{
    public class MPURedundancyService : MPUService.IM3YBSCommunicationCallback, IDisposable
    {
        public void A1VehicleDoorStatusChanged(bool A1VehicleDoorStatus)
        {
        }

        public void A2VehicleDoorStatusChanged(bool A2VehicleDoorStatus)
        {
        }

        public void B1VehicleDoorStatusChanged(bool B1VehicleDoorStatus)
        {
        }

        public void C1VehicleDoorStatusChanged(bool C1VehicleDoorStatus)
        {
        }

        public void DD_CMileageKm_1Changed(int DD_CMileageKm_1)
        {
        }

        public void EVR_CResetDistChanged(bool EVR_CResetDist)
        {
        }

        public void EVR_ICountDistChanged(int EVR_ICountDist)
        {
            
        }

        public void MPUConnectionStatusChanged(MPUService.EnumsCommunication communication, MPUService.EnumsConnection connection)
        {
           
        }

        public void VB_DRS_OpenDoorsLeftChanged(bool VB_DRS_OpenDoorsLeft)
        {
        }

        public void VB_DRS_OpenDoorsRightChanged(bool VB_DRS_OpenDoorsRight)
        {
        }

        public void VB_DRS_TLLeftDrsReleasedChanged(bool VB_DRS_TLLeftDrsReleased)
        {
        }

        public void VB_DRS_TLRightDrsReleasedChanged(bool VB_DRS_TLRightDrsReleased)
        {
        }

        public void VI_TBS_TrainSpeedKphChanged(int VI_TBS_TrainSpeedKph)
        {
        }

        public void Dispose()
        {
        }

        public void NotifyMasterMPUForResetEVRDistanceStatus(string masterMPU, bool EVR_ICountDist)
        {

        }

        public void AnnouncementStatusChanged(MPUService.AnnouncementDTO announcementDTO)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=========================================");
            sb.AppendLine("Anons Talebi Geldi.");
            sb.AppendLine("Metro Hattı : " + announcementDTO.metroLines.ToString());

            if ((announcementDTO.announcementType == MPUService.EnumsAnnouncementType.Station) || (announcementDTO.announcementType == MPUService.EnumsAnnouncementType.Approach) || (announcementDTO.announcementType == MPUService.EnumsAnnouncementType.Interchange))
                sb.AppendLine("İstasyon Adı : " + announcementDTO.stationName.ToString());
            
            sb.AppendLine("Anons Türü : " + announcementDTO.announcementType.ToString());
            sb.AppendLine("Anons Talebi : " + announcementDTO.status.ToString());
            sb.AppendLine("=========================================");

            DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, sb.ToString());

            MainForm.m_mf.m_test = false;

            ThreadPool.QueueUserWorkItem(new WaitCallback(AnnounceHelper.PrepareAnnounceFilePath), announcementDTO);

        }

        public void MPUBehaviorChanged(EnumsCommunication communication, EnumsMPUType MPUType, string masterMPUName)
        {
           
        }

        public void MPURedundancyStateChanged(int redundancyState, string MPUName)
        {
            
        }

        public void VolumeStatusChanged(int volume)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(MainForm.ChangeVolume), volume);
        }

        public void VolumeMuteStatusChanged(bool mute)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(MainForm.MuteVolume), mute);
        }
    }
}
