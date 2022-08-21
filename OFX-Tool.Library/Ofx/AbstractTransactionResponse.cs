using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library.Ofx
{
    public class AbstractTransactionResponse : AbstractResponse
    {
        public string? TransactionUniqueId { get; set; }
        public Status? Status { get; set; }
        public string? ClientCookie { get; set; }
    }
}
