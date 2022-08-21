using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractSTMTTRN
    {
        internal StatementTransaction Element { get; }

        internal ExtractSTMTTRN(XmlTextReader xmlReader)
        {
            Element = new StatementTransaction();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("STMTTRN"))
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
                        case "TRNTYPE":
                            Element.TransactionType = (TransactionEnum)Enum.Parse(typeof(TransactionEnum), xmlReader.Value);
                            break;
                        case "DTPOSTED":
                            Element.PostedDate = xmlReader.Value;
                            break;
                        case "DTUSER":
                            Element.UserDate = xmlReader.Value;
                            break;
                        case "TRNAMT":
                            Element.TransactionAmount = xmlReader.Value;
                            break;
                        case "FITID":
                            Element.FinancialInstitutionTransactionId = xmlReader.Value;
                            break;
                        case "CHECKNUM":
                            Element.CheckNumber = xmlReader.Value;
                            break;
                        case "MEMO":
                            Element.Memo = xmlReader.Value;
                            break;
                    }
                }
            }
        }
    }
}
