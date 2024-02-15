using MPUMessenger.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
{
   
    public class MPU : IDoorsStatus, IDoorsReleaseStatus, IOneSideDoorStatus, IVehicleMovement, IRedundancyState
    {  
        private bool m_A1VehicleDoorStatus = false, m_A2VehicleDoorStatus = false, m_C1VehicleDoorStatus = false, m_B1VehicleDoorStatus = false;
        private bool m_VB_DRS_OpenDoorsLeft = false, m_VB_DRS_OpenDoorsRight = false, m_VB_DRS_TLLeftDrsReleased = false, m_VB_DRS_TLRightDrsReleased = false;
        private int m_EVR_ICountDist, m_VI_TBS_TrainSpeedKph, m_DD_CMileageKm_1;
        private bool m_EVR_CResetDist = false;
        private int m_redundancyState;
        private Enums.MPUType m_MPUType = Enums.MPUType.Undefined;

        #region cabindoor
        public bool A1VehicleDoorStatus
        {
            get { return m_A1VehicleDoorStatus; }
            set
            { 

                if (value != m_A1VehicleDoorStatus)
                { 
                    m_A1VehicleDoorStatus = value; 

                    if (m_A1VehicleDoorStatus)
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxA1VehicleDoor, Resources.dooropen);
                    else
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxA1VehicleDoor, Resources.doorclose);

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.A1VehicleDoorStatus = m_A1VehicleDoorStatus;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    } 
                }
            }
        }
        public bool A2VehicleDoorStatus
        {
            get { return m_A2VehicleDoorStatus; }
            set
            {
                if (value != m_A2VehicleDoorStatus)
                {
                    m_A2VehicleDoorStatus = value;

                    if (m_A2VehicleDoorStatus)
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxA2VehicleDoor, Resources.dooropen);
                    else
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxA2VehicleDoor, Resources.doorclose);

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.A2VehicleDoorStatus = m_A2VehicleDoorStatus;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
            }
        }

        public bool B1VehicleDoorStatus
        {
            get { return m_B1VehicleDoorStatus; }
            set
            {
                if (value != m_B1VehicleDoorStatus)
                {
                    m_B1VehicleDoorStatus = value;

                    if (m_B1VehicleDoorStatus)
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxB1VehicleDoor, Resources.dooropen);
                    else
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxB1VehicleDoor, Resources.doorclose);

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.B1VehicleDoorStatus = m_B1VehicleDoorStatus;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
            }
        }

        public bool C1VehicleDoorStatus
        {
            get { return m_C1VehicleDoorStatus; }
            set
            {
                if (value != m_C1VehicleDoorStatus)
                {
                    m_C1VehicleDoorStatus = value;

                    if (m_C1VehicleDoorStatus)
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxC1VehicleDoor, Resources.dooropen);
                    else
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxC1VehicleDoor, Resources.doorclose);

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.C1VehicleDoorStatus = m_C1VehicleDoorStatus;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
            }
        }


        #endregion

        #region doorstatus
        public bool VB_DRS_OpenDoorsLeft
        {
            get { return m_VB_DRS_OpenDoorsLeft; }
            set
            {
                if (value != m_VB_DRS_OpenDoorsLeft)
                {
                    m_VB_DRS_OpenDoorsLeft = value;

                    if (m_VB_DRS_OpenDoorsLeft)
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxOpenDoorsLeft, Resources.dooropen);
                    else
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxOpenDoorsLeft, Resources.doorclose);

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.VB_DRS_OpenDoorsLeft = m_VB_DRS_OpenDoorsLeft;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
            }
        }

        public bool VB_DRS_OpenDoorsRight
        {
            get { return m_VB_DRS_OpenDoorsRight; }
            set
            {
                if (value != m_VB_DRS_OpenDoorsRight)
                {
                    m_VB_DRS_OpenDoorsRight = value;

                    if (m_VB_DRS_OpenDoorsRight)
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxOpenDoorsRight, Resources.dooropen);
                    else
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxOpenDoorsRight, Resources.doorclose);

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.VB_DRS_OpenDoorsRight = m_VB_DRS_OpenDoorsRight;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
            }
        }

        public bool VB_DRS_TLLeftDrsReleased
        {
            get { return m_VB_DRS_TLLeftDrsReleased; }
            set
            {
                if (value != m_VB_DRS_TLLeftDrsReleased)
                {
                    m_VB_DRS_TLLeftDrsReleased = value;

                    if (m_VB_DRS_TLLeftDrsReleased)
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxTLLeftDrsReleased, Resources.doorokrelease_rotatate);
                    else
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxTLLeftDrsReleased, Resources.doorcancelrelease_rotate);
                    
                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.VB_DRS_TLLeftDrsReleased = m_VB_DRS_TLLeftDrsReleased;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
            }
        }

        public bool VB_DRS_TLRightDrsReleased
        {
            get { return m_VB_DRS_TLRightDrsReleased; }
            set
            {
                if (value != m_VB_DRS_TLRightDrsReleased)
                {
                    m_VB_DRS_TLRightDrsReleased = value;

                    if (m_VB_DRS_TLRightDrsReleased)
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxTLRightDrsReleased, Resources.doorokrelease_rotatate);
                    else
                        DisplayManager.PictureBoxInvoke(MainForm.m_mf.m_pictureBoxTLRightDrsReleased, Resources.doorcancelrelease_rotate);

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.VB_DRS_TLRightDrsReleased = m_VB_DRS_TLRightDrsReleased;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
            }
        }
        #endregion

        #region speedinfo
        public int VI_TBS_TrainSpeedKph
        {
            get { return m_VI_TBS_TrainSpeedKph; }
            set
            {
                if (value != m_VI_TBS_TrainSpeedKph)
                {
                    m_VI_TBS_TrainSpeedKph = value;

                    DisplayManager.TextBoxInvoke(MainForm.m_mf.m_textBoxSpeed, m_VI_TBS_TrainSpeedKph.ToString());

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.VI_TBS_TrainSpeedKph = m_VI_TBS_TrainSpeedKph;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
            }
        }

        public int EVR_ICountDist
        {
            get { return m_EVR_ICountDist; }
            set
            {
                if (value != m_EVR_ICountDist)
                {
                    m_EVR_ICountDist = value;

                    DisplayManager.TextBoxInvoke(MainForm.m_mf.m_textBoxDistanceCounter, m_EVR_ICountDist.ToString());

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.EVR_ICountDist = m_EVR_ICountDist;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                       
                }
            }
        }

        public int DD_CMileageKm_1
        {
            get { return m_DD_CMileageKm_1; }
            set
            {
                if (value != m_DD_CMileageKm_1)
                {
                    m_DD_CMileageKm_1 = value;

                    DisplayManager.TextBoxInvoke(MainForm.m_mf.m_textBoxMileageKm, m_DD_CMileageKm_1.ToString());

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.DD_CMileageKm_1 = m_DD_CMileageKm_1;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
            }
        }

        public bool EVR_CResetDist
        {
            get { return m_EVR_CResetDist; }
            set
            {
                if (value != m_EVR_CResetDist)
                {
                    m_EVR_CResetDist = value;

                    if(m_EVR_CResetDist)
                        MainForm.m_mf.m_radioButtonDistanceCounterResetTrue.Checked = true;
                    else
                        MainForm.m_mf.m_radioButtonDistanceCounterResetFalse.Checked = true;

                    if (MainForm.m_mf.m_mpuServiceMPU != null)
                    {
                        MainForm.m_mf.m_mpuServiceMPU.EVR_CResetDist = m_EVR_CResetDist;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
            }
        }
        #endregion


        public Enums.MPUType MPUType
        {
            get { return m_MPUType; }
            set
            {
                if ((value != m_MPUType) && (!MPURedundancy.Singleton().MPUCommunicationStatus))
                {
                    m_MPUType = Enums.MPUType.Undefined;

                    DisplayManager.ToolStripStatusLabelInvoke(MainForm.m_mf.m_toolStripStatusLabelMPUBehavior, m_MPUType.ToString());

                    if ((MainForm.m_mf.m_mpuServiceMPU != null) && (MainForm.m_mf.m_client != null))
                    {
                        MainForm.m_mf.m_mpuServiceMPU.MPUType = MPUService.EnumsMPUType.Undefined;
                        MainForm.m_mf.m_client.MPUStatusAsync(MainForm.m_mf.m_mpuServiceMPU);
                    }
                }
                else if ((value != m_MPUType) && (MPURedundancy.Singleton().MPUCommunicationStatus))
                {
                    m_MPUType = value;

                    DisplayManager.ToolStripStatusLabelInvoke(MainForm.m_mf.m_toolStripStatusLabelMPUBehavior, m_MPUType.ToString());

                    if ((MainForm.m_mf.m_mpuServiceMPU != null) && (MainForm.m_mf.m_client != null))
                    {
                        MainForm.m_mf.m_settings = MainForm.m_mf.m_settings.DeSerialize(MainForm.m_mf.m_settings);

                        MPUService.EnumsCommunication enumsCommunication;

                        if (m_MPUType == Enums.MPUType.Undefined)
                            MainForm.m_mf.m_mpuServiceMPU.MPUType = MPUService.EnumsMPUType.Undefined;
                        else if ((m_MPUType == Enums.MPUType.Master) && (MPURedundancy.Singleton().MPUCommunicationStatus))
                            MainForm.m_mf.m_mpuServiceMPU.MPUType = MPUService.EnumsMPUType.Master;
                        else if ((m_MPUType == Enums.MPUType.Slave) && (MPURedundancy.Singleton().MPUCommunicationStatus))
                            MainForm.m_mf.m_mpuServiceMPU.MPUType = MPUService.EnumsMPUType.Slave;

                        if (MainForm.m_mf.m_settings.CommunicationType == Enums.Communication.MPU)
                            enumsCommunication = MPUService.EnumsCommunication.MPU;
                        else
                            enumsCommunication = MPUService.EnumsCommunication.MPU_RED;

                        MainForm.m_mf.m_client.MPUBehaviorStatusAsync(enumsCommunication, MainForm.m_mf.m_mpuServiceMPU.MPUType);
                    }
                }
            }
        }

        public int RedundancyState
        {
            get { return m_redundancyState; }
            set
            {
                if (value != m_redundancyState)
                {
                    m_redundancyState = value;
                    string status = "";
                    System.Drawing.Color color = System.Drawing.SystemColors.Control; 

                    if (m_redundancyState == 1)// değer 1 ise durumu
                    {
                        status = Enums.MPUType.Master.ToString();
                        color = System.Drawing.Color.Turquoise;
                    }

                    else if (m_redundancyState == 2)
                    {
                        status = Enums.MPUType.Slave.ToString();
                        color = System.Drawing.Color.Yellow;
                    }

                    else if (m_redundancyState == 0)
                    {
                        status = Enums.MPUType.Undefined.ToString();
                        color = System.Drawing.SystemColors.Control;
                    }

                    DisplayManager.ToolStripStatusLabelInvoke(MainForm.m_mf.m_toolStripStatusLabelMPUBehavior, status, color);

                    if ((MainForm.m_mf.m_mpuServiceMPU != null) && (MainForm.m_mf.m_client != null))
                    {
                        if (m_redundancyState == 1)// değer 1 ise durumu
                            MainForm.m_mf.m_mpuServiceMPU.MPUType = MPUService.EnumsMPUType.Master;
                        else if (m_redundancyState == 2)
                            MainForm.m_mf.m_mpuServiceMPU.MPUType = MPUService.EnumsMPUType.Slave;
                        else if (m_redundancyState == 0)
                            MainForm.m_mf.m_mpuServiceMPU.MPUType = MPUService.EnumsMPUType.Undefined;

                        MainForm.m_mf.m_settings = MainForm.m_mf.m_settings.DeSerialize(MainForm.m_mf.m_settings);

                        MainForm.m_mf.m_client.MPURedundancyStatusAsync(m_redundancyState, MainForm.m_mf.m_settings.CommunicationType.ToString());
                    }
                }
            }
        }

    }
}
