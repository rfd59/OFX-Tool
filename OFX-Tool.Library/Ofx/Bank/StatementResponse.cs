namespace RFD.OFXTool.Library.Ofx.Bank
{
    public class StatementResponse
    {
        public CurrencyEnum? Currency { get; set; }
        public BankAccount? BankAccountFrom { get; set; }
        public BankTransactionList? BankTransactionList { get; set; }
        public LedgerBalance? LedgerBalance { get; set; }
        public AvailableBalance? AvailableBalance { get; set; }
    }
}