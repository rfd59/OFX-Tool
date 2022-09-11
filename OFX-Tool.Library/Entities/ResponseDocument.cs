using RFD.OFXTool.Library.Attributes;

namespace RFD.OFXTool.Library.Entities
{
    [Element("OFX")]
    public class ResponseDocument
    {
        public SignonResponseMessageSetV1? SignonResponseMessageSetV1 { get; set; }
        public BankResponseMessageSetV1? BankResponseMessageSetV1 { get; set; }

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
                ResponseDocument e = (ResponseDocument)obj;

                return Entity.PropertyEquality(e.SignonResponseMessageSetV1, SignonResponseMessageSetV1) &&
                     Entity.PropertyEquality(e.BankResponseMessageSetV1, BankResponseMessageSetV1);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { SignonResponseMessageSetV1, BankResponseMessageSetV1 }.GetHashCode();
    }
}
