using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
{
    public interface IVehicleMovement
    {
        int VI_TBS_TrainSpeedKph { get; set; }
        int EVR_ICountDist { get; set; }
        bool EVR_CResetDist { get; set; }
        int DD_CMileageKm_1 { get; set; }
    }
}
