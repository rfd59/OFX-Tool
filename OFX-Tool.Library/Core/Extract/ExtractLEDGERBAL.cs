using RFD.OFXTool.Library.Entities;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractLEDGERBAL
    {
        internal LedgerBalance Element { get; }

        internal ExtractLEDGERBAL(XmlTextReader xmlReader)
        {
            Element = new LedgerBalance();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("LEDGERBAL"))
                {
                    break;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    switch (myField)
                    {
                        case "BALAMT":
                            Element.BalanceAmount = xmlReader.Value;
                            break;
                        case "DTASOF":
                            Element.DateAsOf = xmlReader.Value;
                            break;
                    }
                }
            }
        }
    }
}
