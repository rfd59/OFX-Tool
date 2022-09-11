using RFD.OFXTool.Library.Entities.Bank;

namespace RFD.OFXTool.Library.Core.Build
{
    internal class BuildBANKACCTFROM : BuildAbstract<BankAccount>
    {
        public BuildBANKACCTFROM(BankAccount doc, int level = 0) : base(doc, level)
        {
        }

        protected override void BuildElement(BankAccount doc)
        {
            if (doc.BankId != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<BankAccount>(nameof(BankAccount.BankId)).Name, doc.BankId, Level));
            if (doc.BranchId != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<BankAccount>(nameof(BankAccount.BranchId)).Name, doc.BranchId, Level));
            if (doc.AccountId != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<BankAccount>(nameof(BankAccount.AccountId)).Name, doc.AccountId, Level));
            if (doc.AccountType != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<BankAccount>(nameof(BankAccount.AccountType)).Name, doc.AccountType.ToString(), Level));
            if (doc.AccountKey != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<BankAccount>(nameof(BankAccount.AccountKey)).Name, doc.AccountKey, Level));
        }
    }
}