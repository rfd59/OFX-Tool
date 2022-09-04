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
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("BANKACCTFROM"))
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
                        case "BANKID":
                            Element.BankId = xmlReader.Value;
                            break;
                        case "BRANCHID":
                            Element.BranchId = xmlReader.Value;
                            break;
                        case "ACCTID":
                            Element.AccountId = xmlReader.Value;
                            break;
                        case "ACCTTYPE":
                            Element.AccountType = (AccountEnum)Enum.Parse(typeof(AccountEnum), xmlReader.Value);
                            break;
                        default:
                            throw new InvalidOperationException($"Unexpected value! [{myField}]");
                    }
                }
            }
        }
    }
}
