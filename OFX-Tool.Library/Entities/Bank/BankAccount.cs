using RFD.OFXTool.Library.Attributes;
using RFD.OFXTool.Library.Enums;

namespace RFD.OFXTool.Library.Entities.Bank
{
    // OFX uses the Banking Account aggregates to identify an account at an FI. The
    // aggregates contain enough information to uniquely identify an account for the
    // purposes of statement download, bill payment, and funds transfer.
    [Element("BANKACCTFROM")]
    public class BankAccount
    {
        // Gets or sets the bank identifier.
        [Element("BANKID")]
        public string? BankId { get; set; }
        // Gets or sets the branch identifier. May be required for some non-US banks.
        [Element("BRANCHID")]
        public string? BranchId { get; set; }
        // Gets or sets the account identifier.
        [Element("ACCTID")]
        public string? AccountId { get; set; }
        // Gets or sets the account type
        [Element("ACCTTYPE")]
        public AccountEnum? AccountType { get; set; }
        // Gets or sets the checksum.
        [Element("ACCTKEY")]
        public string? AccountKey { get; set; }

        // Determines whether the specified object is equal to the current object.
        public override bool Equals(object? obj)
        {
            // Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                BankAccount e = (BankAccount)obj;
                return Entity.PropertyEquality(e.BankId, BankId) &&
                    Entity.PropertyEquality(e.BranchId, BranchId) &&
                    Entity.PropertyEquality(e.AccountId, AccountId) &&
                    Entity.PropertyEquality(e.AccountType, AccountType) &&
                    Entity.PropertyEquality(e.AccountKey, AccountKey);
            }
        }

        // Serves as the default hash function
        public override int GetHashCode() => new { BankId, BranchId, AccountId, AccountType, AccountKey }.GetHashCode();
    }
}