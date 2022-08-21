namespace RFD.OFXTool.Library.Ofx.Bank
{
    public class StatementTransactionResponse : AbstractTransactionResponse
    {
        public StatementResponse? StatementResponse { get; set; }

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
                StatementTransactionResponse e = (StatementTransactionResponse)obj;
                return Entity.PropertyEquality(e.TransactionUniqueId, TransactionUniqueId) &&
                    Entity.PropertyEquality(e.Status, Status) &&
                    Entity.PropertyEquality(e.ClientCookie, ClientCookie) &&
                    Entity.PropertyEquality(e.StatementResponse, StatementResponse);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { TransactionUniqueId, Status, ClientCookie, StatementResponse }.GetHashCode();
    }
}
