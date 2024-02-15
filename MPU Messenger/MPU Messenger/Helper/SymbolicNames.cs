using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
{
   struct SymbolicNames
    {
        public const string VB_DRS_DoorOpen_A1 = "/MPU_taskmpu/drs1/VB_DRS_DoorOpen_A1";
        public const string VB_DRS_DoorOpen_A2 = "/MPU_taskmpu/drs1/VB_DRS_DoorOpen_A2";
        public const string VB_DRS_DoorOpen_C1 = "/MPU_taskmpu/drs1/VB_DRS_DoorOpen_C1";
        public const string VB_DRS_DoorOpen_B1 = "/MPU_taskmpu/drs1/VB_DRS_DoorOpen_B1";

        public const string VB_DRS_OpenDoorsLeft = "/MPU_taskmpu/drs1/open_ext_drs1/VB_DRS_OpenDoorsLeft";
        public const string VB_DRS_OpenDoorsRight = "/MPU_taskmpu/drs1/open_ext_drs1/VB_DRS_OpenDoorsRight";

        public const string VB_DRS_TLLeftDrsReleased = "/MPU_taskmpu/drs1/release_ext_drs2/mpu_rel_ext_drs_trainline1/VB_DRS_TLLeftDrsReleased";
        public const string VB_DRS_TLRightDrsReleased = "/MPU_taskmpu/drs1/release_ext_drs2/mpu_rel_ext_drs_trainline1/VB_DRS_TLRightDrsReleased";

        public const string DD_CMileageKm_1 = "/MPU_taskmpu/evr1/DD_CMileageKm_1";
        public const string VI_TBS_TrainSpeedKph = "/MPU_taskmpu/pai1/trigger_automatic_msg1/mpu_manage_distance_counter/VI_TBS_TrainSpeedKph";

        public const string EVR_CResetDist = "/MPU_taskmpu/pai1/trigger_automatic_msg1/mpu_manage_distance_counter/EVR_CResetDist";
        public const string EVR_ICountDist = "/MPU_taskmpu/pai1/trigger_automatic_msg1/mpu_manage_distance_counter/EVR_ICountDist";

        public const string UMC_CPreRecordMsgCtrlVal = "/MPU_taskmpu/pai1/manage_predef_messages/mpu_manage_special_messages/UMC_CPreRecordMsgCtrlVal";
        public const string UMC_CPreRecordMsgIdx = "/MPU_taskmpu/pai1/manage_predef_messages/mpu_manage_special_messages/UMC_CPreRecordMsgIdx";

        public const string MPU_CMPU1Master = "/MPU_taskmpu/tcn1/tcn_control1/tcn_control_redundancy/mpu_retrieve_mpu_master1/MPU_CMPU1Master";
        public const string MPU_CMPU2Master = "/MPU_taskmpu/tcn1/tcn_control1/tcn_control_redundancy/mpu_retrieve_mpu_master1/MPU_CMPU2Master";
        public const string RedundancyState = "/MPU_taskmpu/tcn1/tcn_control1/tcn_control_redundancy/mpu_retrieve_mpu_master1/redundancyState";


    }
}
