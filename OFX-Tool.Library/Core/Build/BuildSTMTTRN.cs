using RFD.OFXTool.Library.Entities.Bank;

namespace RFD.OFXTool.Library.Core.Build
{
    internal class BuildSTMTTRN : BuildAbstract<StatementTransaction>
    {
        public BuildSTMTTRN(StatementTransaction doc, int level = 0) : base(doc, level)
        {
        }

        protected override void BuildElement(StatementTransaction doc)
        {
            if (doc.TransactionType != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.TransactionType)).Name, doc.TransactionType.ToString(), Level));
            if (doc.UserDate != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.UserDate)).Name, doc.UserDate, Level));
            if (doc.PostedDate != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.PostedDate)).Name, doc.PostedDate, Level));
            if (doc.TransactionAmount != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.TransactionAmount)).Name, doc.TransactionAmount, Level));
            if (doc.FinancialInstitutionTransactionId != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.FinancialInstitutionTransactionId)).Name, doc.FinancialInstitutionTransactionId, Level));
            if (doc.CheckNumber != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.CheckNumber)).Name, doc.CheckNumber, Level));
            if (doc.Memo != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.Memo)).Name, doc.Memo, Level));
            if (doc.Name != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.Name)).Name, doc.Name, Level));
            if (doc.PayeeId != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.PayeeId)).Name, doc.PayeeId, Level));
            if (doc.StandardIndustrialCode != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.StandardIndustrialCode)).Name, doc.StandardIndustrialCode, Level));
            if (doc.ExtendedName != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.ExtendedName)).Name, doc.ExtendedName, Level));
            if (doc.ReferenceNumber != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.ReferenceNumber)).Name, doc.ReferenceNumber, Level));
            if (doc.ServerTransactionId != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.ServerTransactionId)).Name, doc.ServerTransactionId, Level));
            if (doc.CorrectFinancialInstitutionTransactionId != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.CorrectFinancialInstitutionTransactionId)).Name, doc.CorrectFinancialInstitutionTransactionId, Level));
            if (doc.AvailableDate != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransaction>(nameof(StatementTransaction.AvailableDate)).Name, doc.AvailableDate, Level));
        }
    }
}