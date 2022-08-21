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
    internal class ExtractSTMTRS
    {
        internal StatementResponse Element { get; }

        internal ExtractSTMTRS(XmlTextReader xmlReader)
        {
            Element = new StatementResponse();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("STMTRS"))
                {
                    break;
                }

                // BANKACCTFROM element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("BANKACCTFROM"))
                {
                    Element.BankAccountFrom = new ExtractBANKACCTFROM(xmlReader).Element;
                }

                // BANKTRANLIST element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("BANKTRANLIST"))
                {
                    Element.BankTransactionList = new ExtractBANKTRANLIST(xmlReader).Element;
                }

                // LEDGERBAL element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("LEDGERBAL"))
                {
                    Element.LedgerBalance = new ExtractLEDGERBAL(xmlReader).Element;
                }

                // AVAILBAL element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("AVAILBAL"))
                {
                    Element.AvailableBalance = new ExtractAVAILBAL(xmlReader).Element;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    switch (myField)
                    {
                        case "CURDEF":
                            Element.Currency = (CurrencyEnum)Enum.Parse(typeof(CurrencyEnum), xmlReader.Value);
                            break;
                    }
                }
            }
        }
    }
}
