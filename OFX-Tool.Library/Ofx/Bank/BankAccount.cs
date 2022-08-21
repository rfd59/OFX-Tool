namespace RFD.OFXTool.Library.Ofx.Bank
{
    //
    // Résumé :
    //     OFX uses the Banking Account aggregates to identify an account at an FI. The
    //     aggregates contain enough information to uniquely identify an account for the
    //     purposes of statement download, bill payment, and funds transfer.
    public class BankAccount
    {
        //
        // Résumé :
        //     Gets or sets the bank identifier.
        public string? BankId { get; set; }
        //
        // Résumé :
        //     Gets or sets the branch identifier. May be required for some non-US banks.
        public string? BranchId { get; set; }
        //
        // Résumé :
        //     Gets or sets the account identifier.
        public string? AccountId { get; set; }
        //
        // Résumé :
        //     Gets or sets the account type
        public AccountEnum? AccountType { get; set; }
        //
        // Résumé :
        //     Gets or sets the checksum.
        public string? AccountKey { get; set; }
    }
}