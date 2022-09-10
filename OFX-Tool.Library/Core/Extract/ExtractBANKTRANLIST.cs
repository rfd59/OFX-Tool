using RFD.OFXTool.Library.Entities.Bank;
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
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals(Entity.GetElementClass<BankTransactionList>().Name))
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
                    if (myField == Entity.GetElementProperty<BankTransactionList>(nameof(BankTransactionList.StartDate)).Name)
                        Element.StartDate = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<BankTransactionList>(nameof(BankTransactionList.EndDate)).Name)
                        Element.EndDate = xmlReader.Value;
                    else
                        throw new InvalidOperationException($"Unexpected value! [{myField}]");
                }
            }
        }
    }
}
