using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
{
    public class MPURedundancy
    {
        #region singletonpattern
        private static MPURedundancy m_do ;
        public static MPURedundancy Singleton()
        {
                if (m_do == null)
                    m_do = new MPURedundancy();

                return m_do;
        }
        #endregion
        #region propery
        private bool m_MPUCommunicationStatus;
        public bool MPUCommunicationStatus
        {
            get { return m_MPUCommunicationStatus; }
            set
            {
                if (value != m_MPUCommunicationStatus)
                {
                    m_MPUCommunicationStatus = value;

                    MainForm.m_mf.m_settings = MainForm.m_mf.m_settings.DeSerialize(MainForm.m_mf.m_settings);

                    //mpu ile bağlantı durumunu kullanıcıya göstermek için
                    if (m_MPUCommunicationStatus)
                        DisplayManager.ToolStripStatusLabelInvoke(MainForm.m_mf.m_toolStripStatusLabelMPUName, MainForm.m_mf.m_settings.CommunicationType.ToString(), Color.Green);
                    else
                    {
                        DisplayManager.ToolStripStatusLabelInvoke(MainForm.m_mf.m_toolStripStatusLabelMPUName, MainForm.m_mf.m_settings.CommunicationType.ToString(), Color.Red);
                        
                        MainForm.m_mf.m_MPUToClientProperties.RedundancyState = 0;
                    }

                    if (MainForm.m_mf.m_client != null)
                    { 
                        if ((MPUCommunicationStatus) && (MainForm.m_mf.m_settings.CommunicationType == Enums.Communication.MPU))
                            MainForm.m_mf.m_client.MPUConnectionStatusAsync( MPUService.EnumsCommunication.MPU,MPUService.EnumsConnection.CONNECTED);
                        else if ((!MPUCommunicationStatus) && (MainForm.m_mf.m_settings.CommunicationType == Enums.Communication.MPU))
                                MainForm.m_mf.m_client.MPUConnectionStatusAsync(MPUService.EnumsCommunication.MPU, MPUService.EnumsConnection.CONNECTION_LOST);
                        else if ((MPUCommunicationStatus) && (MainForm.m_mf.m_settings.CommunicationType == Enums.Communication.MPU_RED))
                            MainForm.m_mf.m_client.MPUConnectionStatusAsync(MPUService.EnumsCommunication.MPU_RED, MPUService.EnumsConnection.CONNECTED);
                        else if ((!MPUCommunicationStatus) && (MainForm.m_mf.m_settings.CommunicationType == Enums.Communication.MPU_RED))
                            MainForm.m_mf.m_client.MPUConnectionStatusAsync(MPUService.EnumsCommunication.MPU_RED, MPUService.EnumsConnection.CONNECTION_LOST);
                    }
                       
                }
            }
        }
        #endregion
     
    }
}
