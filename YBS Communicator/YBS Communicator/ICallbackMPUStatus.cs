using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace M3YBSCommunication
{
    public interface ICallbackMPUStatus
    {
        [OperationContract(IsOneWay = true)]
        void MPUConnectionStatusChanged(Enums.Communication communication, Enums.Connection connection);

        [OperationContract(IsOneWay = true)]
        void MPUBehaviorChanged(Enums.Communication communication, Enums.MPUType MPUType, string masterMPUName);

        [OperationContract(IsOneWay = true)]
        void MPURedundancyStateChanged(int redundancyState, string MPUName);

        [OperationContract(IsOneWay = true)]
        void A1VehicleDoorStatusChanged(bool A1VehicleDoorStatus);
        [OperationContract(IsOneWay = true)]
        void A2VehicleDoorStatusChanged(bool A2VehicleDoorStatus);
        [OperationContract(IsOneWay = true)]
        void C1VehicleDoorStatusChanged(bool C1VehicleDoorStatus);
        [OperationContract(IsOneWay = true)]
        void B1VehicleDoorStatusChanged(bool B1VehicleDoorStatus);
        [OperationContract(IsOneWay = true)]
        void VB_DRS_TLLeftDrsReleasedChanged(bool VB_DRS_TLLeftDrsReleased);
        [OperationContract(IsOneWay = true)]
        void VB_DRS_TLRightDrsReleasedChanged(bool VB_DRS_TLRightDrsReleased);
        [OperationContract(IsOneWay = true)]
        void VB_DRS_OpenDoorsLeftChanged(bool VB_DRS_OpenDoorsLeft);
        [OperationContract(IsOneWay = true)]
        void VB_DRS_OpenDoorsRightChanged(bool VB_DRS_OpenDoorsRight); 
        [OperationContract(IsOneWay = true)]
        void VI_TBS_TrainSpeedKphChanged(int VI_TBS_TrainSpeedKph);
        [OperationContract(IsOneWay = true)]
        void EVR_ICountDistChanged(int EVR_ICountDist);

        [OperationContract(IsOneWay = true)]
        void VolumeStatusChanged(int volume);

        [OperationContract(IsOneWay = true)]
        void VolumeMuteStatusChanged(bool mute);


        [OperationContract(IsOneWay = true)]
        void NotifyMasterMPUForResetEVRDistanceStatus(string masterMPU, bool EVR_ICountDist);
      

        [OperationContract(IsOneWay = true)]
        void EVR_CResetDistChanged(bool EVR_CResetDist);
        [OperationContract(IsOneWay = true)]
        void DD_CMileageKm_1Changed(int DD_CMileageKm_1);

        [OperationContract(IsOneWay = true)]
        void AnnouncementStatusChanged(AnnouncementDTO announcementDTO);

        
    }
}
