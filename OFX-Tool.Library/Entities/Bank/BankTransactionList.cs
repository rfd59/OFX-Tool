using RFD.OFXTool.Library.Attributes;

namespace RFD.OFXTool.Library.Entities.Bank
{
    [Element("BANKTRANLIST", ElementTypeEnum.CLASS)]
    public class BankTransactionList
    {
        //
        // Résumé :
        //     Gets or sets the start date for transaction data.
        [Element("DTSTART", ElementTypeEnum.PROPERTY)]
        public string? StartDate { get; set; }
        //
        // Résumé :
        //     Gets or sets the end date for transaction data.
        [Element("DTEND", ElementTypeEnum.PROPERTY)]
        public string? EndDate { get; set; }
        //
        // Résumé :
        //     Gets or sets the collection of Aspose.Finance.Ofx.StatementTransaction.
        public List<StatementTransaction>? StatementTransactions { get; set; }

        // Determines whether the specified object is equal to the current object.
        public override bool Equals(object? obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                BankTransactionList e = (BankTransactionList)obj;
                return Entity.PropertyEquality(e.StartDate, StartDate) &&
                    Entity.PropertyEquality(e.EndDate, EndDate) &&
                    Entity.PropertyEquality(e.StatementTransactions, StatementTransactions);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { StartDate, EndDate, StatementTransactions }.GetHashCode();
    }
}