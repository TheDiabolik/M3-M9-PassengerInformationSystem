using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3YBSCommunication
{
    public interface IDoorsStatus
    {
        bool A1VehicleDoorStatus { get; set; }
        bool A2VehicleDoorStatus { get; set; }
        bool C1VehicleDoorStatus { get; set; }
        bool B1VehicleDoorStatus { get; set; }
    }
}
