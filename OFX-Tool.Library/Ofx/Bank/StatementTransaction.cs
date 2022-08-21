namespace RFD.OFXTool.Library.Ofx.Bank
{
    public class StatementTransaction
    {
       // Gets or sets the transaction type.
        public TransactionEnum? TransactionType { get; set; }
       // Gets or sets the date user initiated transaction, if known.
        public string? UserDate { get; set; }
       // Gets or sets the date transaction was posted to account.
        public string? PostedDate { get; set; }
       // Gets or sets the amount of transaction.
        public string? TransactionAmount { get; set; }
       // Gets or sets the transaction ID issued by financial institution.
        public string? FinancialInstitutionTransactionId { get; set; }
       // Gets or sets the check number.
        public string? CheckNumber { get; set; }
       // Gets or sets the extra information.
        public string? Memo { get; set; }
       // Gets or sets the name of payee or description of transaction.
        public string? Name { get; set; }
       // Gets or sets the payee identifier if available.
        public string? PayeeId { get; set; }
       // Gets or sets the Standard Industrial Code.
        public string? StandardIndustrialCode { get; set; }
       // Gets or sets the extended name of payee or description of transaction.
        public string? ExtendedName { get; set; }
       // Gets or sets the reference number that uniquely identifies the transaction.
        public string? ReferenceNumber { get; set; }
       // Gets or sets the server assigned transaction ID.
        public string? ServerTransactionId { get; set; }
       // Gets or sets the corrected transaction ID. If present, the FinancialInstitutionTransactionId of a previously sent transaction that is corrected by this record.
        public string? CorrectFinancialInstitutionTransactionId { get; set; }
       // Gets or sets the date funds are available (value date).
        public string? AvailableDate { get; set; }

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
                StatementTransaction e = (StatementTransaction)obj;
                return Entity.PropertyEquality(e.TransactionType, TransactionType) &&
                    Entity.PropertyEquality(e.UserDate, UserDate) &&
                    Entity.PropertyEquality(e.PostedDate, PostedDate) &&
                    Entity.PropertyEquality(e.TransactionAmount, TransactionAmount) &&
                    Entity.PropertyEquality(e.FinancialInstitutionTransactionId, FinancialInstitutionTransactionId) &&
                    Entity.PropertyEquality(e.CheckNumber, CheckNumber) &&
                    Entity.PropertyEquality(e.Memo, Memo) &&
                    Entity.PropertyEquality(e.Name, Name) &&
                    Entity.PropertyEquality(e.PayeeId, PayeeId) &&
                    Entity.PropertyEquality(e.StandardIndustrialCode, StandardIndustrialCode) &&
                    Entity.PropertyEquality(e.ExtendedName, ExtendedName) &&
                    Entity.PropertyEquality(e.ReferenceNumber, ReferenceNumber) &&
                    Entity.PropertyEquality(e.ServerTransactionId, ServerTransactionId) &&
                    Entity.PropertyEquality(e.CorrectFinancialInstitutionTransactionId, CorrectFinancialInstitutionTransactionId) &&
                    Entity.PropertyEquality(e.AvailableDate, AvailableDate);
            }
        }

        // Serves as the default hash function
        public override int GetHashCode() => new
        {
            TransactionType,
            UserDate,
            PostedDate,
            TransactionAmount,
            FinancialInstitutionTransactionId,
            CheckNumber,
            Memo,
            Name,
            PayeeId,
            StandardIndustrialCode,
            ExtendedName,
            ReferenceNumber,
            ServerTransactionId,
            CorrectFinancialInstitutionTransactionId,
            AvailableDate
        }.GetHashCode();
    }
}