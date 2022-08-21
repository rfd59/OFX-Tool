namespace RFD.OFXTool.Library.Ofx.Bank
{
    public class StatementTransactionResponse : AbstractTransactionResponse
    {
        //
        // Résumé :
        //     Gets or sets the Aspose.Finance.Ofx.OfxExtensionType.
        public OfxExtensionType? OfxExtension { get; set; }
        //
        // Résumé :
        //     Gets or sets the Aspose.Finance.Ofx.Bank.StatementTransactionResponse.StatementResponse.
        public StatementResponse? StatementResponse { get; set; }
    }
}