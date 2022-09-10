using RFD.OFXTool.Library.Attributes;

namespace RFD.OFXTool.Library.Entities.Signon
{
    [Element("SONRS", ElementTypeEnum.CLASS)]
    public class SignonResponse
    {
        public Status? Status { get; set; }
        [Element("DTSERVER", ElementTypeEnum.PROPERTY)]
        public string? ServerDate { get; set; }
        [Element("LANGUAGE", ElementTypeEnum.PROPERTY)] 
        public LanguageEnum? Language { get; set; }

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
                SignonResponse e = (SignonResponse)obj;
                return Entity.PropertyEquality(e.Status, Status) &&
                    Entity.PropertyEquality(e.ServerDate, ServerDate) &&
                    Entity.PropertyEquality(e.Language, Language);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { Status, ServerDate, Language }.GetHashCode();
    }
}