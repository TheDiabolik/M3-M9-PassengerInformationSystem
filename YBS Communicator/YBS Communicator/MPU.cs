using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace M3YBSCommunication
{
    [DataContract]
    public class MPU : IDoorsStatus, IDoorsReleaseStatus, IOneSideDoorStatus, IVehicleMovement
    {
        [DataMember]
        public Enums.Communication communication;
        [DataMember]
        public Enums.Connection connection = Enums.Connection.NOT_CONNECTED;

        [DataMember]
        public bool A1VehicleDoorStatus { get; set; }
        [DataMember]
        public bool A2VehicleDoorStatus { get; set; }
        [DataMember]
        public bool C1VehicleDoorStatus { get; set; }
        [DataMember]
        public bool B1VehicleDoorStatus { get; set; }
        [DataMember]
        public bool VB_DRS_TLLeftDrsReleased { get; set; }
        [DataMember]
        public bool VB_DRS_TLRightDrsReleased { get; set; }
        [DataMember]
        public bool VB_DRS_OpenDoorsLeft { get; set; }
        [DataMember]
        public bool VB_DRS_OpenDoorsRight { get; set; }
        [DataMember]
        public int VI_TBS_TrainSpeedKph { get; set; }
        [DataMember]
        public int EVR_ICountDist { get; set; }
        [DataMember]
        public bool EVR_CResetDist { get; set; }
        [DataMember]
        public int DD_CMileageKm_1 { get; set; }

        [DataMember]
        public Enums.MPUType MPUType { get; set; }
    }
}
