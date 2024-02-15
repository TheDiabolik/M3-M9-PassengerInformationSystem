using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MPUMessenger
{
    internal class XMLMessageHelper
    {
        public static string PrepareAddTraceDefinationVariablesXML()
        {
            string generetedAddTraceDefinitionString = "";

            try
            {
                XmlDocument soapRequest = new XmlDocument();
                soapRequest.LoadXml("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><AddTraceDefinition xmlns=\"urn:WEB-TRC\"></AddTraceDefinition></soap:Body></soap:Envelope>");

                XmlNamespaceManager namespaces = new XmlNamespaceManager(soapRequest.NameTable);
                namespaces.AddNamespace("rate", "urn:WEB-TRC");

                XmlNode addTraceDefinition = soapRequest.SelectSingleNode("//rate:AddTraceDefinition", namespaces);

                XmlElement oTraceDefinition = soapRequest.CreateElement("oTraceDefinition");

                XmlElement sDashInfo = soapRequest.CreateElement("sTraceName");
                sDashInfo.InnerText = "YBS";

                oTraceDefinition.AppendChild(sDashInfo);

                XmlElement oVariableVector = soapRequest.CreateElement("oVariableVector");

                foreach (var item in MainForm.m_mf.m_addedAddedVariables)
                {
                    XmlElement oVarList = soapRequest.CreateElement("oVarList");

                    XmlElement varId = soapRequest.CreateElement("varId");
                    varId.InnerText = item.VariableId; ;

                    oVarList.AppendChild(varId);
                    
                    oVariableVector.AppendChild(oVarList);
                }

                oTraceDefinition.AppendChild(oVariableVector);

                XmlElement oChange = soapRequest.CreateElement("oChange");
                oChange.InnerText = "AUTHORIZED";

                oTraceDefinition.AppendChild(oChange);

                XmlElement sTraceInfo = soapRequest.CreateElement("sTraceInfo");
                sTraceInfo.InnerText = "tracer,dashboard";

                oTraceDefinition.AppendChild(sTraceInfo);

                addTraceDefinition.AppendChild(oTraceDefinition);
                
                generetedAddTraceDefinitionString = soapRequest.OuterXml;

                return generetedAddTraceDefinitionString;
            }
            catch (Exception ex)
            {
                DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, ExceptionMessages.PrepareGetVariablesXML);

                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "PrepareGetVariablesXML");

                return generetedAddTraceDefinitionString;
            }
        }

        public static string PrepareGetVariablesXML()
        {
            string generetedGetInformationString = "";

            try
            {
                XmlDocument soapRequest = new XmlDocument();
                soapRequest.LoadXml("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><GetVariablesInformation xmlns=\"urn:WEB-TRC\"></GetVariablesInformation></soap:Body></soap:Envelope>");

                XmlNamespaceManager namespaces = new XmlNamespaceManager(soapRequest.NameTable);
                namespaces.AddNamespace("rate", "urn:WEB-TRC");

                XmlNode getVariablesInformation = soapRequest.SelectSingleNode("//rate:GetVariablesInformation", namespaces);

                foreach (var item in MainForm.m_mf.m_addedAddedVariables)
                {
                    XmlElement oVariableIds = soapRequest.CreateElement("oVariableIds");

                    XmlElement sDashInfo = soapRequest.CreateElement("sDashInfo");
                    sDashInfo.InnerText = "tracer";

                    XmlElement oVariableId = soapRequest.CreateElement("oVariableId");
                    oVariableId.InnerText = item.VariableId;

                    oVariableIds.AppendChild(sDashInfo);
                    oVariableIds.AppendChild(oVariableId);

                    getVariablesInformation.AppendChild(oVariableIds);
                }

                generetedGetInformationString = soapRequest.OuterXml;

                return generetedGetInformationString;
            }
            catch (Exception ex)
            {
                DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, ExceptionMessages.PrepareGetVariablesXML);

                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "PrepareGetVariablesXML");

                return generetedGetInformationString;
            }
        }

        public static void AddVariablesResponseParseMessage(string soapMessage)
        {
            try
            {
                MainForm.m_mf.m_addedAddedVariables.Clear();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(soapMessage);

                XmlNode bodyNode = xmlDoc.GetElementsByTagName("SOAP-ENV:Body")[0];
                if (bodyNode != null)
                {
                    XmlNode responseNode = bodyNode.FirstChild;
                    if (responseNode != null)
                    {
                        XmlNode xmlNode = responseNode.LastChild;

                        if (xmlNode != null && xmlNode.LocalName == "SetOfAddedVariables")
                        {
                            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
                            {
                                XmlNode root = xmlNode.ChildNodes[i];

                                if (root.HasChildNodes)
                                {
                                    AddedAddedVariable addedVariable = new AddedAddedVariable();

                                    for (int j = 0; j < root.ChildNodes.Count; j++)
                                    {
                                        var sdfsd = root.ChildNodes[j].InnerXml;

                                        var rgrg = root.ChildNodes[j].Name;
                                        if (root.ChildNodes[j].Name == "ns3:SymbolicName")
                                        {
                                            addedVariable.SymbolicName = root.ChildNodes[j].InnerText.Trim();
                                        }
                                        else if (root.ChildNodes[j].Name == "ns3:ProdId")
                                        {
                                            addedVariable.ProdId = root.ChildNodes[j].InnerText.Trim();
                                        }
                                        else if (root.ChildNodes[j].Name == "ns3:Size")
                                        {
                                            addedVariable.Size = root.ChildNodes[j].InnerText.Trim();
                                        }
                                        else if (root.ChildNodes[j].Name == "ns3:Type")
                                        {
                                            addedVariable.Type = root.ChildNodes[j].InnerText.Trim();
                                        }
                                        else if (root.ChildNodes[j].Name == "ns3:Reference")
                                        {
                                            addedVariable.Reference = root.ChildNodes[j].InnerText.Trim();
                                        }
                                        else if (root.ChildNodes[j].Name == "ns3:ReferenceCB")
                                        {
                                            addedVariable.ReferenceCB = root.ChildNodes[j].InnerText.Trim();
                                        }
                                        else if (root.ChildNodes[j].Name == "ns3:VariableId")
                                        {
                                            addedVariable.VariableId = root.ChildNodes[j].InnerText.Trim();
                                        }
                                        else if (root.ChildNodes[j].Name == "ns3:ActionStatus")
                                        {
                                            addedVariable.ActionStatus = root.ChildNodes[j].InnerText.Trim();
                                        }
                                    }

                                    MainForm.m_mf.m_addedAddedVariables.Add(addedVariable);
                                }
                            }
                        }

                    }
                }
                else
                {
                    DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, "SOAP Response not found.");
                }
            }
            catch (Exception ex)
            {
                DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, ExceptionMessages.AddVariablesResponseExceptionMessage);

                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AddVariablesResponseParseMessage");
            }
        }

        public static void GetVariablesInformationResponseParseMessage(string soapMessage)
        {
            try
            {
                MainForm.m_mf.m_oVariablesInformations.Clear();
                
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(soapMessage);

                XmlNode bodyNode = xmlDoc.GetElementsByTagName("SOAP-ENV:Body")[0];
                if (bodyNode != null)
                {
                    XmlNode responseNode = bodyNode.FirstChild;
                    if (responseNode != null && responseNode.LocalName == "GetVariablesInformationResponse")
                    {
                        for (int i = 0; i < responseNode.ChildNodes.Count; i++)
                        {
                            XmlNode root = responseNode.ChildNodes[i];

                            if (root.HasChildNodes)
                            {
                                GetVariablesMessage coming = new GetVariablesMessage();

                                for (int j = 0; j < root.ChildNodes.Count; j++)
                                {
                                    if (root.ChildNodes[j].Name == "varId")
                                    {
                                        coming.varId = root.ChildNodes[j].InnerText;
                                    }
                                    else if (root.ChildNodes[j].Name == "oForceOption")
                                    {
                                        coming.oForceOption = root.ChildNodes[j].InnerText;
                                    }
                                    else if (root.ChildNodes[j].Name == "oVarType")
                                    {
                                        coming.oVarType = root.ChildNodes[j].InnerText;
                                    }
                                    else if (root.ChildNodes[j].Name == "tabSize")
                                    {
                                        coming.tabSize = root.ChildNodes[j].InnerText;
                                    }
                                    else if (root.ChildNodes[j].Name == "asciiData")
                                    {
                                        coming.asciiData = root.ChildNodes[j].InnerText.Trim();
                                    }
                                }

                                MainForm.m_mf.m_oVariablesInformations.Add(coming);
                            }
                        }

                        #region set reading parameters

                        foreach (GetVariablesMessage item in MainForm.m_mf.m_oVariablesInformations)
                        {
                            AddedAddedVariable resultAddedVarible = MainForm.m_mf.m_addedAddedVariables.Find(x => x.VariableId == item.varId);

                            MainForm.m_mf.m_settings = MainForm.m_mf.m_settings.DeSerialize(MainForm.m_mf.m_settings);

                            if (resultAddedVarible.SymbolicName == SymbolicNames.VB_DRS_DoorOpen_A1)
                            {
                                if (item.asciiData == "1")
                                    MainForm.m_mf.m_MPUToClientProperties.A1VehicleDoorStatus = true;
                                else
                                    MainForm.m_mf.m_MPUToClientProperties.A1VehicleDoorStatus = false;
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.VB_DRS_DoorOpen_A2)
                            {
                                if (item.asciiData == "1")
                                    MainForm.m_mf.m_MPUToClientProperties.A2VehicleDoorStatus = true;
                                else
                                    MainForm.m_mf.m_MPUToClientProperties.A2VehicleDoorStatus = false;
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.VB_DRS_DoorOpen_C1)
                            {
                                if (item.asciiData == "1")
                                    MainForm.m_mf.m_MPUToClientProperties.C1VehicleDoorStatus = true;
                                else
                                    MainForm.m_mf.m_MPUToClientProperties.C1VehicleDoorStatus = false;
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.VB_DRS_DoorOpen_B1)
                            {
                                if (item.asciiData == "1")
                                    MainForm.m_mf.m_MPUToClientProperties.B1VehicleDoorStatus = true;
                                else
                                    MainForm.m_mf.m_MPUToClientProperties.B1VehicleDoorStatus = false;
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.VB_DRS_OpenDoorsLeft)
                            {
                                if (item.asciiData == "1")
                                    MainForm.m_mf.m_MPUToClientProperties.VB_DRS_OpenDoorsLeft = true;
                                else
                                    MainForm.m_mf.m_MPUToClientProperties.VB_DRS_OpenDoorsLeft = false;
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.VB_DRS_OpenDoorsRight)
                            {
                                if (item.asciiData == "1")
                                    MainForm.m_mf.m_MPUToClientProperties.VB_DRS_OpenDoorsRight = true;
                                else
                                    MainForm.m_mf.m_MPUToClientProperties.VB_DRS_OpenDoorsRight = false;
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.VB_DRS_TLLeftDrsReleased)
                            {
                                if (item.asciiData == "1")
                                    MainForm.m_mf.m_MPUToClientProperties.VB_DRS_TLLeftDrsReleased = true;
                                else
                                    MainForm.m_mf.m_MPUToClientProperties.VB_DRS_TLLeftDrsReleased = false;
                            }

                            else if (resultAddedVarible.SymbolicName == SymbolicNames.VB_DRS_TLRightDrsReleased)
                            {
                                if (item.asciiData == "1")
                                    MainForm.m_mf.m_MPUToClientProperties.VB_DRS_TLRightDrsReleased = true;
                                else
                                    MainForm.m_mf.m_MPUToClientProperties.VB_DRS_TLRightDrsReleased = false;
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.VI_TBS_TrainSpeedKph)
                            {
                                MainForm.m_mf.m_MPUToClientProperties.VI_TBS_TrainSpeedKph = int.Parse(item.asciiData);
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.EVR_ICountDist)
                            {
                                MainForm.m_mf.m_MPUToClientProperties.EVR_ICountDist = Convert.ToInt32(item.asciiData);
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.DD_CMileageKm_1)
                            {
                                MainForm.m_mf.m_MPUToClientProperties.DD_CMileageKm_1 = int.Parse(item.asciiData);
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.EVR_CResetDist)
                            {
                                if (item.asciiData == "1")
                                    MainForm.m_mf.m_MPUToClientProperties.EVR_CResetDist = true;
                                else
                                    MainForm.m_mf.m_MPUToClientProperties.EVR_CResetDist = false;
                            }
                            else if (resultAddedVarible.SymbolicName == SymbolicNames.RedundancyState)
                            {
                                if (item.asciiData == "1")
                                    MainForm.m_mf.m_MPUToClientProperties.RedundancyState = 1;
                                else
                                    MainForm.m_mf.m_MPUToClientProperties.RedundancyState = 2;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("****************************************************");
                        sb.AppendLine("____________________________________________________");
                        sb.AppendLine("MPU Bağlantı Hatası!!!...");
                        sb.AppendLine("____________________________________________________");
                        sb.AppendLine("****************************************************");
                        DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBox, ExceptionMessages.GetVariablesExceptionMessage);
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "GetVariablesInformationResponseParseMessage");
            }
        }

        public static string PrepareResetDistanceCounterMessage(AddedAddedVariable addedAddedVariable, Enums.ForceOption forceOption, bool resetDistanceCounter)
        {
            string generetedResetDistanceCounterString = "";

            XmlDocument soapRequest = new XmlDocument();
            soapRequest.LoadXml("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><DashboardSetVarValues xmlns=\"urn:WEB-TRC\"></DashboardSetVarValues></soap:Body></soap:Envelope>");

            XmlNamespaceManager namespaces = new XmlNamespaceManager(soapRequest.NameTable);
            namespaces.AddNamespace("rate", "urn:WEB-TRC");

            XmlNode dashboardSetVarValues = soapRequest.SelectSingleNode("//rate:DashboardSetVarValues", namespaces);

            XmlElement oControlInfo = soapRequest.CreateElement("oControlInfo");

            XmlElement sGlobalIdentifier = soapRequest.CreateElement("sGlobalIdentifier");
            sGlobalIdentifier.InnerText = "tracer,tracerCCN,tracerCCU";

            oControlInfo.AppendChild(sGlobalIdentifier);

            dashboardSetVarValues.AppendChild(oControlInfo);

            XmlElement oVarValues = soapRequest.CreateElement("oVarValues");

            XmlElement sDashInfo = soapRequest.CreateElement("sDashInfo");
            sDashInfo.InnerText = "tracer";
            oVarValues.AppendChild(sDashInfo);

            XmlElement varId = soapRequest.CreateElement("varId");
            varId.InnerText = addedAddedVariable.VariableId;
            oVarValues.AppendChild(varId);

            XmlElement oForceOption = soapRequest.CreateElement("oForceOption");

            XmlElement asciiData = soapRequest.CreateElement("asciiData");

            if (forceOption == Enums.ForceOption.FORCE)
            {
                oForceOption.InnerText = "FORCE";

                string asciiDataValueToSend;

                if (resetDistanceCounter)
                    asciiDataValueToSend = "1";
                else
                    asciiDataValueToSend = "0";

                asciiData.InnerText = asciiDataValueToSend;
            }
            else
            {
                oForceOption.InnerText = "UNFORCE";
            }

            oVarValues.AppendChild(oForceOption);
            oVarValues.AppendChild(asciiData);

            dashboardSetVarValues.AppendChild(oVarValues);

            generetedResetDistanceCounterString = soapRequest.OuterXml;

            return generetedResetDistanceCounterString;
        }

        public static string PrepareAhmetMessage(AddedAddedVariable addedAddedVariable, Enums.ForceOption forceOption, int announcementID)
        {
            string generetedResetDistanceCounterString = "";

            XmlDocument soapRequest = new XmlDocument();
            soapRequest.LoadXml("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><DashboardSetVarValues xmlns=\"urn:WEB-TRC\"></DashboardSetVarValues></soap:Body></soap:Envelope>");

            XmlNamespaceManager namespaces = new XmlNamespaceManager(soapRequest.NameTable);
            namespaces.AddNamespace("rate", "urn:WEB-TRC");

            XmlNode dashboardSetVarValues = soapRequest.SelectSingleNode("//rate:DashboardSetVarValues", namespaces);
            
            XmlElement oControlInfo = soapRequest.CreateElement("oControlInfo");

            XmlElement sGlobalIdentifier = soapRequest.CreateElement("sGlobalIdentifier");
            sGlobalIdentifier.InnerText = "tracer,tracerCCN,tracerCCU";

            oControlInfo.AppendChild(sGlobalIdentifier);

            dashboardSetVarValues.AppendChild(oControlInfo);

            XmlElement oVarValues = soapRequest.CreateElement("oVarValues");

            XmlElement sDashInfo = soapRequest.CreateElement("sDashInfo");
            sDashInfo.InnerText = "tracer";
            oVarValues.AppendChild(sDashInfo);

            XmlElement varId = soapRequest.CreateElement("varId");
            varId.InnerText = addedAddedVariable.VariableId;
            oVarValues.AppendChild(varId);

            XmlElement oForceOption = soapRequest.CreateElement("oForceOption");

            XmlElement asciiData = soapRequest.CreateElement("asciiData");

            if (forceOption == Enums.ForceOption.FORCE)
            {
                oForceOption.InnerText = "FORCE";

                string asciiDataValueToSend = announcementID.ToString();

                asciiData.InnerText = asciiDataValueToSend;
            }
            else
            {
                oForceOption.InnerText = "UNFORCE";
            }

            oVarValues.AppendChild(oForceOption);

            oVarValues.AppendChild(asciiData);

            dashboardSetVarValues.AppendChild(oVarValues);

            generetedResetDistanceCounterString = soapRequest.OuterXml;

            return generetedResetDistanceCounterString;
        }
    }
}
