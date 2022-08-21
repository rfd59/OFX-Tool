using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library.Ofx
{
    public class ResponseDocument
    {

        public SignonResponseMessageSetV1? SignonResponseMessageSetV1 { get; set; }
        public BankResponseMessageSetV1? BankResponseMessageSetV1 { get; set; }
    }
}
