using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using RFD.OFXTool.Library.Enums;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal class BANKACCTFROM : ElementAbstract<BankAccount>
    {
        protected override void BuildElement(BankAccount doc)
        {
            if (doc.BankId != null)
                _build.AppendLine(WriteProperty<BankAccount>(nameof(BankAccount.BankId), doc.BankId, _level));
            if (doc.BranchId != null)
                _build.AppendLine(WriteProperty<BankAccount>(nameof(BankAccount.BranchId), doc.BranchId, _level));
            if (doc.AccountId != null)
                _build.AppendLine(WriteProperty<BankAccount>(nameof(BankAccount.AccountId), doc.AccountId, _level));
            if (doc.AccountType != null)
                _build.AppendLine(WriteProperty<BankAccount>(nameof(BankAccount.AccountType), doc.AccountType, _level));
            if (doc.AccountKey != null)
                _build.AppendLine(WriteProperty<BankAccount>(nameof(BankAccount.AccountKey), doc.AccountKey, _level));
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            if (xmlReader.NodeType == XmlNodeType.Text)
            {
                if (_field == Entity.GetElement<BankAccount>(nameof(BankAccount.BankId)))
                    _load.BankId = xmlReader.Value;
                else if (_field == Entity.GetElement<BankAccount>(nameof(BankAccount.BranchId)))
                    _load.BranchId = xmlReader.Value;
                else if (_field == Entity.GetElement<BankAccount>(nameof(BankAccount.AccountId)))
                    _load.AccountId = xmlReader.Value;
                else if (_field == Entity.GetElement<BankAccount>(nameof(BankAccount.BranchId)))
                    _load.BranchId = xmlReader.Value;
                else if (_field == Entity.GetElement<BankAccount>(nameof(BankAccount.AccountType)))
                    _load.AccountType = (AccountEnum)Enum.Parse(typeof(AccountEnum), xmlReader.Value);
                else if (_field == Entity.GetElement<BankAccount>(nameof(BankAccount.AccountKey)))
                    _load.AccountKey = xmlReader.Value;
                else
                    throw new InvalidOperationException($"Unexpected value! [{_field}]");
            }
        }
    }
}