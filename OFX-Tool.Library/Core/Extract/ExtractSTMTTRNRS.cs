using RFD.OFXTool.Library.Ofx.Bank;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractSTMTTRNRS
    {
        internal StatementTransactionResponse Element { get; }

        internal ExtractSTMTTRNRS(XmlTextReader xmlReader)
        {
            Element = new StatementTransactionResponse();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("STMTTRNRS"))
                {
                    break;
                }

                // STATUS element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("STATUS"))
                {
                    Element.Status = new ExtractSTATUS(xmlReader).Element;
                }

                // STMTRS element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("STMTRS"))
                {
                    Element.StatementResponse = new ExtractSTMTRS(xmlReader).Element;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    switch (myField)
                    {
                        case "TRNUID":
                            Element.TransactionUniqueId = xmlReader.Value;
                            break;
                    }
                }
            }
        }
    }
}
