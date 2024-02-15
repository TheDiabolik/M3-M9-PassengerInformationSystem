using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
{
    public struct GetVariablesMessage
    {
        public string varId;
        public string oForceOption;
        public string oVarType;
        public string tabSize;
        public string asciiData;
    }
}
