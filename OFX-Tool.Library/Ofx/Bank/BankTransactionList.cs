namespace RFD.OFXTool.Library.Ofx.Bank
{
    public class BankTransactionList
    {
        //
        // Résumé :
        //     Gets or sets the start date for transaction data.
        public string? StartDate { get; set; }
        //
        // Résumé :
        //     Gets or sets the end date for transaction data.
        public string? EndDate { get; set; }
        //
        // Résumé :
        //     Gets or sets the collection of Aspose.Finance.Ofx.StatementTransaction.
        public List<StatementTransaction>? StatementTransactions { get; set; }
    }
}