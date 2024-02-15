using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3YBSCommunication
{
    public struct AnnouncementDTO
    {
        public Enums.MetroLines metroLines;
        public Enums.StationName stationName;
        public Enums.AnnouncementType announcementType;
        public Enums.Announcement status;
        public string privateAnnouncementFileName;
    }
}
