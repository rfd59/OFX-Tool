using RFD.OFXTool.Library.Ofx;
using RFD.OFXTool.Library.Ofx.Bank;
using RFD.OFXTool.Library.Ofx.Signon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractBANKTRANLIST
    {
        internal BankTransactionList Element { get; }

        internal ExtractBANKTRANLIST(XmlTextReader xmlReader)
        {
            Element = new BankTransactionList();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("BANKTRANLIST"))
                {
                    break;
                }

                // STMTTRN element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("STMTTRN"))
                {
                    if (Element.StatementTransactions == null)
                    {
                        Element.StatementTransactions = new List<StatementTransaction>();
                    }

                    Element.StatementTransactions.Add(new ExtractSTMTTRN(xmlReader).Element);
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    switch (myField)
                    {
                        case "DTSTART":
                            Element.StartDate = xmlReader.Value;
                            break;
                        case "DTEND":
                            Element.EndDate = xmlReader.Value;
                            break;
                    }
                }
            }
        }
    }
}
