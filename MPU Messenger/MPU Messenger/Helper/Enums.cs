using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
{
    public class Enums
    {
        public enum Communication { MPU, MPU_RED }
        public enum ForceOption { FORCE, UNFORCE }
        public enum Connection { CONNECTED, CONNECTION_LOST }
        public enum WorkType { Single, Redundant }
        public enum ReadingSoapMessageType{ FilePath, XMLString }
        public enum MPUType { Undefined, Master, Slave }

    }
}
