using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
{
    internal struct AnnouncementDTO
    {
        public MPUService.EnumsStationName stationName;
        public MPUService.EnumsAnnouncementType announcementType;
        public MPUService.EnumsAnnouncement status;
    }
}
