using RFD.OFXTool.Library.Core.Elements;
using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library.Core
{
    public class BuildToFile
    {
        public string OfxFile { get; }

        public ResponseDocument OfxDocument { get; }

        public BuildToFile(ResponseDocument doc, string file)
        {
            OfxDocument = doc;
            OfxFile = file;

            Build();
        }

        private void Build()
        {
            // Writing data into target file
            StreamWriter sw = File.CreateText(OfxFile);
            sw.WriteLine($"<{Entity.GetElement<ResponseDocument>()}>");

            //
            if (OfxDocument.SignonResponseMessageSetV1 != null)
                sw.WriteLine(new SIGNONMSGSRSV1().Build(OfxDocument.SignonResponseMessageSetV1));

            //
            if (OfxDocument.BankResponseMessageSetV1 != null)
                sw.WriteLine(new BANKMSGSRSV1().Build(OfxDocument.BankResponseMessageSetV1));

            sw.WriteLine($"</{Entity.GetElement<ResponseDocument>()}>");
            sw.Close();

        }
    }
}
