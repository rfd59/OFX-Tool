namespace RFD.OFXTool.Library.Ofx.Signon
{
    public class SignonResponse
    {
        public Status? Status { get; set; }
        public string? ServerDate { get; set; }
        public LanguageEnum? Language { get; set; }
    }
}