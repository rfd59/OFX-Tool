namespace RFD.OFXTool.Library.Ofx
{
    public class Status
    {
        //
        // Résumé :
        //     Gets or sets the error code.
        public string? Code { get; set; }
        //
        // Résumé :
        //     Gets or sets the severity of the error.
        public SeverityEnum? Severity { get; set; }
        //
        // Résumé :
        //     Gets or sets the textual explanation from the FI.
        public string? Message { get; set; }
    }
}