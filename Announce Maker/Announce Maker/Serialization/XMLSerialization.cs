using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnounceMaker
{
    [Serializable]

    public class XMLSerialization
    {
        private static XMLSerialization m_xmlSerialization = new XMLSerialization();

        public XMLSerialization()
        {
        }

        #region singleton
        public static XMLSerialization Singleton()
        {
            return m_xmlSerialization;
        }
        #endregion



        #region general settings
        public string M3StationAnnouncementFilePath { get; set; }
        public string M3PrivateAnnouncementFilePath { get; set; }
        public string M9StationAnnouncementFilePath { get; set; }
        public string M9PrivateAnnouncementFilePath { get; set; }
        public bool SaveLog { get; set; }
        public bool ConnectServiceOpenning { get; set; }
        public bool PlaySync { get; set; }
        public bool PlayAsync { get; set; } 
        public bool ShowServiceInfoUI { get; set; }
        #endregion

        #region com settings
        //com ayarları
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public string DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }

        #endregion

        public void CheckSerializationFile()
        {
            try
            {
                //kayıt dosyası exe ile aynı yerde olması istendiği için comment yapıldı
                if (!Directory.Exists(Path.GetDirectoryName(SerializationPaths.Settings)))
                    Directory.CreateDirectory(Path.GetDirectoryName(SerializationPaths.Settings));

                //xmlserilization dosyasını kontrol ediyoruz
                if (!File.Exists(SerializationPaths.Settings))
                {
                    this.M3StationAnnouncementFilePath = "";
                    this.M3PrivateAnnouncementFilePath = "";
                    this.M9StationAnnouncementFilePath = "";
                    this.M9PrivateAnnouncementFilePath = "";
                    this.SaveLog = false;
                    this.PlayAsync = true;
                    this.ConnectServiceOpenning = true;
                    this.ShowServiceInfoUI = true;
                   

                    this.Serialize(XMLSerialization.Singleton());
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionMessages.CheckSerilizationFileExceptionMessage, ex);
            }
        }


        public void Serialize(XMLSerialization serialization)
        {
            Serialization.Serialize(SerializationPaths.Settings, serialization);
        }

        public void SerializeBinary(XMLSerialization serialization)
        {
            Serialization.SerializeBinary(SerializationPaths.BinarySettings, serialization);
        }

        public XMLSerialization DeSerialize(XMLSerialization serialization)
        {
            CheckSerializationFile();
            return Serialization.DeSerialize(SerializationPaths.Settings, serialization);
        }

        public XMLSerialization DeSerializeBinary(XMLSerialization serialization)
        {
            CheckSerializationFile();
            return Serialization.DeSerializeBinary(SerializationPaths.BinarySettings, serialization);
        }

    }
}
