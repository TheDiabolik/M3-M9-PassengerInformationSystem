using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3YBSCommunication
{
    public class Enums
    {
        public enum Communication { MPU, MPU_RED }
        public enum Connection { NOT_CONNECTED, CONNECTED, CONNECTION_LOST  }
       
        public enum MPUType { Undefined, Master, Slave }

        public enum Announcement { Play = 16, Stop = 64 }

        public enum AnnouncementType { Station, Approach, Start, Target, Interchange, Special }

        public enum MetroLines { M3, M9, Common }

        public enum StationName
        {
            KayaşehirMerkez, TopluKonutlar, ŞehirHastanesi, Onurkent, BaşakşehirMetrokent, BaşakKonutları,
            Siteler, TurgutÖzal, İkitelliSanayi, İSTOÇ, Mahmutbey, Yenimahalle, Kirazlı, MollaGürani, Yıldıztepe, İlkyuva, Haznedar,
            İncirli, ÖzgürlükMeydanı, BakırköySahil, Ataköy, Yenibosna, Çobançeşme, YirmiDokuzEkimCumhuriyet, DoğuSanayi, MimarSinan, OnBeşTemmuz, 
            HalkalıCaddesi, AtatürkMahallesi, Bahariye, MASKO, ZiyaGökalpMahallesi, Olimpiyat, NA, DepoSahası
        }
    }
}
