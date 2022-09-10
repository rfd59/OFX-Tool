using RFD.OFXTool.Library.Attributes;

namespace RFD.OFXTool.Library.Entities
{
    public class AbstractTransactionResponse : AbstractResponse
    {
        [Element("TRNUID", ElementTypeEnum.PROPERTY)]
        public string? TransactionUniqueId { get; set; }
        public Status? Status { get; set; }
        [Element("CLTCOOKIE", ElementTypeEnum.PROPERTY)]
        public string? ClientCookie { get; set; }
    }
}
