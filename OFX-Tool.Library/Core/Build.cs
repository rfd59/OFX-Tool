using RFD.OFXTool.Library.Core.Elements;
using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library.Core
{
    internal class Build
    {
        internal string OfxFile { get; }

        internal Ofx Ofx { get; }

        internal Build(Ofx ofx, string ofxTargetFile)
        {
            OfxFile = ofxTargetFile; 
            Ofx = ofx;

            if (ofx.Header != null)
                BuildHeader(ofx.Header);
            if (ofx.Response!= null)
                BuildResponse(ofx.Response);
        }

        private void BuildHeader(HeaderDocument doc)
        {
            //throw new NotImplementedException();
        }

        private void BuildResponse(ResponseDocument doc)
        {
            // Writing data into target file
            StreamWriter sw = File.CreateText(OfxFile);
            sw.WriteLine($"<{Entity.GetElement<ResponseDocument>()}>");

            //
            if (doc.SignonResponseMessageSetV1 != null)
                sw.WriteLine(new SIGNONMSGSRSV1().Build(doc.SignonResponseMessageSetV1));

            //
            if (doc.BankResponseMessageSetV1 != null)
                sw.WriteLine(new BANKMSGSRSV1().Build(doc.BankResponseMessageSetV1));

            sw.WriteLine($"</{Entity.GetElement<ResponseDocument>()}>");
            sw.Close();
        }
    }
}
