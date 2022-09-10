using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractBANKACCTFROM
    {
        internal BankAccount Element { get; }

        internal ExtractBANKACCTFROM(XmlTextReader xmlReader)
        {
            Element = new BankAccount();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals(Entity.GetElementClass<BankAccount>().Name))
                {
                    break;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    if (myField == Entity.GetElementProperty<BankAccount>(nameof(BankAccount.BankId)).Name)
                        Element.BankId = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<BankAccount>(nameof(BankAccount.BranchId)).Name)
                        Element.BranchId = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<BankAccount>(nameof(BankAccount.AccountId)).Name)
                        Element.AccountId = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<BankAccount>(nameof(BankAccount.BranchId)).Name)
                        Element.BranchId = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<BankAccount>(nameof(BankAccount.AccountType)).Name)
                        Element.AccountType = (AccountEnum)Enum.Parse(typeof(AccountEnum), xmlReader.Value);
                    else if (myField == Entity.GetElementProperty<BankAccount>(nameof(BankAccount.AccountKey)).Name)
                        Element.AccountKey = xmlReader.Value;
                    else
                        throw new InvalidOperationException($"Unexpected value! [{myField}]");
                }
            }
        }
    }
}
