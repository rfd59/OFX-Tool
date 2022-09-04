using RFD.OFXTool.Library.Entities.Bank;

namespace RFD.OFXTool.Library.Entities
{
    public class BankResponseMessageSetV1
    {
        public List<StatementTransactionResponse>? StatementTransactionResponses { get; set; }

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
                BankResponseMessageSetV1 e = (BankResponseMessageSetV1)obj;

                return Entity.PropertyEquality(e.StatementTransactionResponses, StatementTransactionResponses);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { StatementTransactionResponses }.GetHashCode();
    }
}