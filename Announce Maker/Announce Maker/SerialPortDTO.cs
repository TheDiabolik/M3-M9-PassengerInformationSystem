using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnounceMaker
{
    public struct SerialPortDTO
    {
        public string portName;
        public int baudRate;
        public int dataBits;
        public Parity parity;
        public StopBits stopBits;
    }
}
