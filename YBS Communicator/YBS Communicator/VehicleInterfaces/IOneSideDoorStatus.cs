using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3YBSCommunication
{
    public interface IOneSideDoorStatus
    {
        bool VB_DRS_OpenDoorsLeft { get; set; }
        bool VB_DRS_OpenDoorsRight { get; set; }
    }
}
