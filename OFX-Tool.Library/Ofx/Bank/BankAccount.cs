namespace RFD.OFXTool.Library.Ofx.Bank
{
    // OFX uses the Banking Account aggregates to identify an account at an FI. The
    // aggregates contain enough information to uniquely identify an account for the
    // purposes of statement download, bill payment, and funds transfer.
    public class BankAccount
    {
        // Gets or sets the bank identifier.
        public string? BankId { get; set; }
        // Gets or sets the branch identifier. May be required for some non-US banks.
        public string? BranchId { get; set; }
        // Gets or sets the account identifier.
        public string? AccountId { get; set; }
        // Gets or sets the account type
        public AccountEnum? AccountType { get; set; }
        // Gets or sets the checksum.
        public string? AccountKey { get; set; }

        // Determines whether the specified object is equal to the current object.
        public override bool Equals(Object? obj)
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