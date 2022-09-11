namespace RFD.OFXTool.Library.Entities
{
    public class Ofx
    {
        public HeaderDocument Header { get; set; }

        public ResponseDocument Response { get; set; }

        public Ofx()
        {
            Header = new HeaderDocument();
            Response = new ResponseDocument();
        }

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
                Ofx e = (Ofx)obj;

                return Entity.PropertyEquality(e.Header, Header) &&
                     Entity.PropertyEquality(e.Response, Response);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { Header, Response }.GetHashCode();
    }
}
