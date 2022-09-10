using RFD.OFXTool.Library.Entities;
using System.Text;

namespace RFD.OFXTool.Library.Core.Build
{
    internal class BuildSIGNONMSGSRSV1 : BuildAbstract<SignonResponseMessageSetV1>
    {
        public BuildSIGNONMSGSRSV1(SignonResponseMessageSetV1 doc, int level = 0) : base(doc, level)
        {
        }

        protected override void BuildElement(SignonResponseMessageSetV1 doc)
        {
            if (doc.SignonResponse != null)
                Element.Append(new BuildSONRS(doc.SignonResponse, Level + 1).Element);
        }
    }
}