namespace RFD.OFXTool.Library.Ofx.Bank
{
    public class StatementTransaction
    {
        //
        // Résumé :
        //     Gets or sets the transaction type.
        public TransactionEnum? TransactionType { get; set; }
        //
        // Résumé :
        //     Gets or sets the date user initiated transaction, if known.
        public string? UserDate { get; set; }
        //
        // Résumé :
        //     Gets or sets the date transaction was posted to account.
        public string? PostedDate { get; set; }
        //
        // Résumé :
        //     Gets or sets the amount of transaction.
        public string? TransactionAmount { get; set; }
        //
        // Résumé :
        //     Gets or sets the transaction ID issued by financial institution.
        public string? FinancialInstitutionTransactionId { get; set; }
        //
        // Résumé :
        //     Gets or sets the check number.
        public string? CheckNumber { get; set; }
        //
        // Résumé :
        //     Gets or sets the extra information.
        public string? Memo { get; set; }
        //
        // Résumé :
        //     Gets or sets the name of payee or description of transaction.
        public string? Name { get; set; }
        //
        // Résumé :
        //     Gets or sets the payee identifier if available.
        public string? PayeeId { get; set; }
        //
        // Résumé :
        //     Gets or sets the Standard Industrial Code.
        public string? StandardIndustrialCode { get; set; }
        //
        // Résumé :
        //     Gets or sets the extended name of payee or description of transaction.
        public string? ExtendedName { get; set; }
        //
        // Résumé :
        //     Gets or sets the reference number that uniquely identifies the transaction.
        public string? ReferenceNumber { get; set; }
        //
        // Résumé :
        //     Gets or sets the server assigned transaction ID.
        public string? ServerTransactionId { get; set; }
        //
        // Résumé :
        //     Gets or sets the corrected transaction ID. If present, the FinancialInstitutionTransactionId
        //     of a previously sent transaction that is corrected by this record.
        public string? CorrectFinancialInstitutionTransactionId { get; set; }
        //
        // Résumé :
        //     Gets or sets the date funds are available (value date).
        public string? AvailableDate { get; set; }
    }
}