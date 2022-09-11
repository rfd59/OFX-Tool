using RFD.OFXTool.Library.Attributes;

namespace RFD.OFXTool.Library.Entities
{
    [Element("OFX")]
    public class ResponseDocument
    {
        public SignonResponseMessageSetV1? SignonResponseMessageSetV1 { get; set; }
        public BankResponseMessageSetV1? BankResponseMessageSetV1 { get; set; }
    }
}
