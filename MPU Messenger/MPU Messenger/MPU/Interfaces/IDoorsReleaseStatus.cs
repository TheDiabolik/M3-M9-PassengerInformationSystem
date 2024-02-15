using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
{
    public interface IDoorsReleaseStatus
    {
        bool VB_DRS_TLLeftDrsReleased { get; set; }
        bool VB_DRS_TLRightDrsReleased { get; set; }
    }
}
