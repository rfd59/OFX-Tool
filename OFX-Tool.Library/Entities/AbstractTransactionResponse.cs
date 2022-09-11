using RFD.OFXTool.Library.Attributes;

namespace RFD.OFXTool.Library.Entities
{
    public class AbstractTransactionResponse : AbstractResponse
    {
        [Element("TRNUID")]
        public string? TransactionUniqueId { get; set; }
        public Status? Status { get; set; }
        [Element("CLTCOOKIE")]
        public string? ClientCookie { get; set; }
    }
}
