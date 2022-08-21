using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library.Ofx
{
    public enum SeverityEnum
    {
        //
        // Résumé :
        //     Informational only
        INFO = 0,
        //
        // Résumé :
        //     Some problem with the request occurred but a valid response still present.
        WARN = 1,
        //
        // Résumé :
        //     A problem severe enough that response could not be made.
        ERROR = 2
    }
}
