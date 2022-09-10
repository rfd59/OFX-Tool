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
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals(Entity.GetElementClass<StatementTransaction>().Name))
                {
                    break;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.TransactionType)).Name)
                        Element.TransactionType = (TransactionEnum)Enum.Parse(typeof(TransactionEnum), xmlReader.Value);
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.PostedDate)).Name)
                        Element.PostedDate = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.UserDate)).Name)
                        Element.UserDate = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.TransactionAmount)).Name)
                        Element.TransactionAmount = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.FinancialInstitutionTransactionId)).Name)
                        Element.FinancialInstitutionTransactionId = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.CheckNumber)).Name)
                        Element.CheckNumber = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.Memo)).Name)
                        Element.Memo = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.Name)).Name)
                        Element.Name = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.PayeeId)).Name)
                        Element.PayeeId = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.StandardIndustrialCode)).Name)
                        Element.StandardIndustrialCode = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.ExtendedName)).Name)
                        Element.ExtendedName = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.ReferenceNumber)).Name)
                        Element.ReferenceNumber = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.ServerTransactionId)).Name)
                        Element.ServerTransactionId = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.CorrectFinancialInstitutionTransactionId)).Name)
                        Element.CorrectFinancialInstitutionTransactionId = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.AvailableDate)).Name)
                        Element.AvailableDate = xmlReader.Value;
                    else
                        throw new InvalidOperationException($"Unexpected value! [{myField}]");
                }
            }
        }
    }
}
