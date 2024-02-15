using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
{
    internal class UIOperation
    {
        public static void MPUCommunicationStatus(bool showMPUCommunicationInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (showMPUCommunicationInfo)
            {  
                sb.AppendLine("****************************************************");

                sb.AppendLine("____________________________________________________");
                sb.AppendLine("Aracın Kilometresi   : " + MainForm.m_mf.m_MPUToClientProperties.DD_CMileageKm_1.ToString());
                sb.AppendLine("Aracın Hızı(km/sa)   : " + MainForm.m_mf.m_MPUToClientProperties.VI_TBS_TrainSpeedKph.ToString());
                sb.AppendLine("Mesafe Sayacı(tur)     : " + MainForm.m_mf.m_MPUToClientProperties.EVR_ICountDist.ToString());
                sb.AppendLine("____________________________________________________");

                sb.AppendLine("____________________________________________________");
                sb.AppendLine("Dizinin Sol Kapıları Serbestlik Durumu   : " + MainForm.m_mf.m_MPUToClientProperties.VB_DRS_TLLeftDrsReleased.ToString());
                sb.AppendLine("Dizinin Sağ Kapıları Serbestlik Durumu   : " + MainForm.m_mf.m_MPUToClientProperties.VB_DRS_TLRightDrsReleased.ToString());
                sb.AppendLine("Araç Dizi Sol Kapı Durumu                : " + MainForm.m_mf.m_MPUToClientProperties.VB_DRS_OpenDoorsLeft.ToString());
                sb.AppendLine("Araç Dizi Sağ Kapı Durumu                : " + MainForm.m_mf.m_MPUToClientProperties.VB_DRS_OpenDoorsRight.ToString());
                sb.AppendLine("____________________________________________________");

                sb.AppendLine("____________________________________________________");
                sb.AppendLine("A1 Araç Kapı Durumu  : " + MainForm.m_mf.m_MPUToClientProperties.A1VehicleDoorStatus.ToString());
                sb.AppendLine("A2 Araç Kapı Durumu  : " + MainForm.m_mf.m_MPUToClientProperties.A2VehicleDoorStatus.ToString());
                sb.AppendLine("C1 Araç Kapı Durumu  : " + MainForm.m_mf.m_MPUToClientProperties.C1VehicleDoorStatus.ToString());
                sb.AppendLine("B1 Araç Kapı Durumu  : " + MainForm.m_mf.m_MPUToClientProperties.B1VehicleDoorStatus.ToString());
                sb.AppendLine("____________________________________________________");

                sb.AppendLine("****************************************************"); 

                DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, sb.ToString());
            } 

            Logging.WriteCommunicationLog(DateTime.Now, sb);
        }
    }
}
