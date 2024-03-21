using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
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
        #region connection
        public int MPUTimeout { get; set; }
        public Enums.Communication CommunicationType { get; set; }
        public Enums.WorkType WorkType { get; set; }
        public bool WriteLog { get; set; }
        public bool ShowRedundancyServiceCommunication { get; set; }
        public bool ShowVehicleStatus { get; set; }
        public bool ConnectMPU { get; set; }
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
                    CommunicationType = Enums.Communication.MPU;
                    WorkType = Enums.WorkType.Redundant;
                    WriteLog = false;
                    ShowRedundancyServiceCommunication = true;
                    ShowVehicleStatus = true;
                    ConnectMPU = true;
                    MPUTimeout = 0;

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
