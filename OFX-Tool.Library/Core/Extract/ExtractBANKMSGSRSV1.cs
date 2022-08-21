using RFD.OFXTool.Library.Ofx;
using RFD.OFXTool.Library.Ofx.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("BANKMSGSRSV1"))
                {
                    break;
                }

                // SONRS element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("STMTTRNRS"))
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
