using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnounceMaker
{
    public static class ToolStripStatusExtensions
    {
        public static void ToolStripStatusInvokeAction<TControlType>(this TControlType control, Action<TControlType> del)
    where TControlType : ToolStripStatusLabel
        {
            if (control.GetCurrentParent().InvokeRequired)
                control.GetCurrentParent().Invoke(new Action(() => del(control)));
            else
                del(control);
        }
    }
}
