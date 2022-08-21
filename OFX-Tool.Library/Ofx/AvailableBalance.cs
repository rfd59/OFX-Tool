using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library.Ofx
{
    public class AvailableBalance
    {
        //
        // Résumé :
        //     Gets or sets the available balance amount.
        public string? BalanceAmount { get; set; }
        //
        // Résumé :
        //     Gets or sets the balance date.
        public string? DateAsOf { get; set; }
    }
}
