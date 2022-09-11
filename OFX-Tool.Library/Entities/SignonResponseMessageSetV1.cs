using RFD.OFXTool.Library.Attributes;
using RFD.OFXTool.Library.Entities.Signon;

namespace RFD.OFXTool.Library.Entities
{
    [Element("SIGNONMSGSRSV1")]
    public class SignonResponseMessageSetV1
    {
        public SignonResponse? SignonResponse { get; set; }

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
                SignonResponseMessageSetV1 e = (SignonResponseMessageSetV1)obj;
                return Entity.PropertyEquality(e.SignonResponse, SignonResponse);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { SignonResponse }.GetHashCode();

    }
}