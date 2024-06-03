using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace M3YBSCommunication
{
    [ServiceContract(CallbackContract = typeof(ICallbackMPUStatus))]
    public interface IM3YBSCommunication
    {
        [OperationContract(IsInitiating = true)]
        bool Subscribe();
        [OperationContract(IsInitiating = true)]
        bool Unsubscribe();
        [OperationContract()]
        void ResetDistanceCounter(bool resetCountDist);

        [OperationContract()]
        void IncreaseDistanceCounter(int increaseCountDist);

        [OperationContract()]
        string HeartBeat(string heartBeat);

        [OperationContract()]
        string HeartBeatWithConnectionCheck(string heartBeat, Enums.Communication communication, Enums.Connection connectionStatus);

        [OperationContract()]
        string HeartBeatWithConnectionAndMPUStatusCheck(string heartBeat, Enums.Communication communication, Enums.Connection connectionStatus, Enums.MPUType mpuType);

        [OperationContract()]
        void MPUStatus(MPU mpu);

        [OperationContract()]
        void MPUConnectionStatus(Enums.Communication communication, Enums.Connection  connectionStatus);
        [OperationContract()]
        void MPUBehaviorStatus(Enums.Communication communication, Enums.MPUType MPUType);

        [OperationContract()]
        void MPURedundancyStatus(int redundancyStatus, string MPUName);
        [OperationContract()]
        MPU AddOrFindInRedundancyMPU(MPU mpu); 

        [OperationContract(IsOneWay = true)]
        void SetMasterVolumeMute(bool mute);
        [OperationContract(IsOneWay = true)]
        void SetMasterVolume(int newLevel);
        [OperationContract()]
        int GetMasterVolume();
        [OperationContract()]
        bool GetMasterVolumeMute();

        [OperationContract()]
        string LearnMPUStatus(string MPUName);

        [OperationContract(IsOneWay = true)]
        void AnnouncementStatus(AnnouncementDTO announcementDTO);
        [OperationContract()]
        string ConvertStationNameEnumToString(Enums.StationName stationName);
        [OperationContract()]
        Enums.StationName ConvertStationNameStringToEnum(string stationName);
      
    }
}
