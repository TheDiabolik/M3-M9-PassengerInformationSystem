using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MPUMessenger
{
    public  class SOAPHelper
    {
        public static HttpWebRequest CreateSOAPWebRequest()
        {
            //Making Web Request  
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://192.168.1.69/cgi-bin/targetTraces");

            //third message
            Req.Headers.Add(@"SOAPAction:http://transport.alstom.com/webservices/targetTraces/StartDashboard");

            //Content_type  
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method  
            Req.Method = "POST";
            //return HttpWebRequest  
            return Req;
        }

        public static string CreateSOAPMessage(string MPUSoapFileName, Enums.ReadingSoapMessageType readingSoapMessageType)
        {
            string serviceResult = "";

            try
            {
                //Calling CreateSOAPWebRequest method  
                HttpWebRequest request = CreateSOAPWebRequest();

                XmlDocument SOAPReqBody = new XmlDocument();
                //SOAP Body Request  
                if (readingSoapMessageType == Enums.ReadingSoapMessageType.XMLString)
                    SOAPReqBody.LoadXml(MPUSoapFileName);
                else
                    SOAPReqBody.Load(MPUSoapFileName);

                using (Stream stream = request.GetRequestStream())
                {
                    SOAPReqBody.Save(stream);
                }

                MainForm.m_mf.m_settings = MainForm.m_mf.m_settings.DeSerialize(MainForm.m_mf.m_settings);

                if (MainForm.m_mf.m_settings.MPUTimeout > 0)
                    request.Timeout = MainForm.m_mf.m_settings.MPUTimeout;

                //Geting response from request  
                using (WebResponse Serviceres = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                    {
                        serviceResult = rd.ReadToEnd();

                        MPURedundancy.Singleton().MPUCommunicationStatus = true;

                        return serviceResult;
                    }
                }
            }
            catch (WebException ex)
            {
                MPURedundancy.Singleton().MPUCommunicationStatus = false;

                return serviceResult;
            }
        }
    }
}
