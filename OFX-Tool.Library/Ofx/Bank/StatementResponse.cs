namespace RFD.OFXTool.Library.Ofx.Bank
{
    public class StatementResponse
    {
        public CurrencyEnum? Currency { get; set; }
        public BankAccount? BankAccountFrom { get; set; }
        public BankTransactionList? BankTransactionList { get; set; }
        public LedgerBalance? LedgerBalance { get; set; }
        public AvailableBalance? AvailableBalance { get; set; }

        // Determines whether the specified object is equal to the current object.
        public override bool Equals(Object? obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                StatementResponse e = (StatementResponse)obj;
                return Entity.PropertyEquality(e.Currency, Currency) &&
                    Entity.PropertyEquality(e.BankAccountFrom, BankAccountFrom) &&
                    Entity.PropertyEquality(e.BankTransactionList, BankTransactionList) &&
                    Entity.PropertyEquality(e.LedgerBalance, LedgerBalance) &&
                    Entity.PropertyEquality(e.AvailableBalance, AvailableBalance);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { Currency, BankAccountFrom, BankTransactionList, LedgerBalance, AvailableBalance }.GetHashCode();
    }
}