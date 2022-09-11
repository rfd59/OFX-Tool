using RFD.OFXTool.Library.Entities;
using System.Text;

namespace RFD.OFXTool.Library.Core.Build
{
    internal class BuildBANKMSGSRSV1 : BuildAbstract<BankResponseMessageSetV1>
    {
        public BuildBANKMSGSRSV1(BankResponseMessageSetV1 doc, int level = 0) : base(doc, level)
        {
        }

        protected override void BuildElement(BankResponseMessageSetV1 doc)
        {
            if (doc.StatementTransactionResponses != null)
            {
                foreach (var str in doc.StatementTransactionResponses)
                    Element.Append(new BuildSTMTTRNRS(str, Level + 1).Element);
            }
        }
    }
}