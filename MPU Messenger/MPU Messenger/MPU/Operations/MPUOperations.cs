using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MPUMessenger
{
    public class MPUOperations
    {
        public static void ResetDistanceCounter(object data)
        {
            bool EVR_ICountDist = (bool)data;

            AddedAddedVariable addedAddedVariable = MainForm.m_mf.m_addedAddedVariables.Find(x => x.SymbolicName == SymbolicNames.EVR_CResetDist);

            string resetCounterMessage;

            resetCounterMessage = XMLMessageHelper.PrepareResetDistanceCounterMessage(addedAddedVariable, Enums.ForceOption.FORCE, EVR_ICountDist);
            //araç üzerinde test ederken commentleri kaldır
            SOAPHelper.CreateSOAPMessage(resetCounterMessage, Enums.ReadingSoapMessageType.XMLString);

            Thread.Sleep(100);

            if (EVR_ICountDist)
            {
                resetCounterMessage = XMLMessageHelper.PrepareResetDistanceCounterMessage(addedAddedVariable, Enums.ForceOption.FORCE, false);
                //araç üzerinde test ederken commentleri kaldır
                SOAPHelper.CreateSOAPMessage(resetCounterMessage, Enums.ReadingSoapMessageType.XMLString);

                Thread.Sleep(100);
            }

            resetCounterMessage = XMLMessageHelper.PrepareResetDistanceCounterMessage(addedAddedVariable, Enums.ForceOption.UNFORCE, EVR_ICountDist);
            //araç üzerinde test ederken commentleri kaldır
            SOAPHelper.CreateSOAPMessage(resetCounterMessage, Enums.ReadingSoapMessageType.XMLString);

        }
        public static void ManageRedundancy(object data)
        {
            if(MainForm.m_mf.m_MPUToClientProperties.MPUType == Enums.MPUType.Master)
                MainForm.m_mf.m_MPUToClientProperties.MPUType = Enums.MPUType.Undefined;
        }
    }
}
