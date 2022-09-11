using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using RFD.OFXTool.Library.Enums;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal class STMTTRN : ElementAbstract<StatementTransaction>
    {
        protected override void BuildElement(StatementTransaction doc)
        {
            if (doc.TransactionType != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.TransactionType), doc.TransactionType, _level));
            if (doc.UserDate != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.UserDate), doc.UserDate, _level));
            if (doc.PostedDate != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.PostedDate), doc.PostedDate, _level));
            if (doc.TransactionAmount != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.TransactionAmount), doc.TransactionAmount, _level));
            if (doc.FinancialInstitutionTransactionId != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.FinancialInstitutionTransactionId), doc.FinancialInstitutionTransactionId, _level));
            if (doc.CheckNumber != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.CheckNumber), doc.CheckNumber, _level));
            if (doc.Memo != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.Memo), doc.Memo, _level));
            if (doc.Name != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.Name), doc.Name, _level));
            if (doc.PayeeId != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.PayeeId), doc.PayeeId, _level));
            if (doc.StandardIndustrialCode != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.StandardIndustrialCode), doc.StandardIndustrialCode, _level));
            if (doc.ExtendedName != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.ExtendedName), doc.ExtendedName, _level));
            if (doc.ReferenceNumber != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.ReferenceNumber), doc.ReferenceNumber, _level));
            if (doc.ServerTransactionId != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.ServerTransactionId), doc.ServerTransactionId, _level));
            if (doc.CorrectFinancialInstitutionTransactionId != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.CorrectFinancialInstitutionTransactionId), doc.CorrectFinancialInstitutionTransactionId, _level));
            if (doc.AvailableDate != null)
                _build.AppendLine(WriteProperty<StatementTransaction>(nameof(StatementTransaction.AvailableDate), doc.AvailableDate, _level));
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            if (xmlReader.NodeType == XmlNodeType.Text)
            {
                if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.TransactionType)))
                    _load.TransactionType = (TransactionEnum)Enum.Parse(typeof(TransactionEnum), xmlReader.Value);
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.PostedDate)))
                    _load.PostedDate = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.UserDate)))
                    _load.UserDate = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.TransactionAmount)))
                    _load.TransactionAmount = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.FinancialInstitutionTransactionId)))
                    _load.FinancialInstitutionTransactionId = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.CheckNumber)))
                    _load.CheckNumber = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.Memo)))
                    _load.Memo = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.Name)))
                    _load.Name = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.PayeeId)))
                    _load.PayeeId = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.StandardIndustrialCode)))
                    _load.StandardIndustrialCode = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.ExtendedName)))
                    _load.ExtendedName = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.ReferenceNumber)))
                    _load.ReferenceNumber = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.ServerTransactionId)))
                    _load.ServerTransactionId = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.CorrectFinancialInstitutionTransactionId)))
                    _load.CorrectFinancialInstitutionTransactionId = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransaction>(nameof(StatementTransaction.AvailableDate)))
                    _load.AvailableDate = xmlReader.Value;
                else
                    throw new InvalidOperationException($"Unexpected value! [{_field}]");
            }
        }
    }
}