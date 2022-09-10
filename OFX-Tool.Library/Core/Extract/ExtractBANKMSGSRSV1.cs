using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractBANKMSGSRSV1
    {
        internal BankResponseMessageSetV1 Element { get; }

        internal ExtractBANKMSGSRSV1(XmlTextReader xmlReader)
        {
            Element = new BankResponseMessageSetV1();

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals(Entity.GetElementClass<BankResponseMessageSetV1>().Name))
                {
                    break;
                }

                // SONRS element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElementClass<StatementTransactionResponse>().Name))
                {
                    if (Element.StatementTransactionResponses == null)
                    {
                        Element.StatementTransactionResponses = new List<StatementTransactionResponse>();
                    }

                    Element.StatementTransactionResponses.Add(new ExtractSTMTTRNRS(xmlReader).Element);
                }
            }
        }
    }
}
