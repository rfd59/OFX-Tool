using RFD.OFXTool.Library.Core.Elements;
using RFD.OFXTool.Library.Entities;
using System.Text;

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
            
            try
            {
                // Writing data into target file
                StreamWriter sw = File.CreateText(OfxFile);
                sw.Write(BuildHeader(ofx.Header));
                sw.Write(BuildResponse(ofx.Response));
                sw.Close();
            } catch (Exception e)
            {
                throw new OFXToolException($"Failed to build the OFX file! [{e.Message}]", e);
            }
        }

        private StringBuilder BuildHeader(HeaderDocument doc)
        {
            var header = new StringBuilder();

            header.AppendLine($"{Entity.GetHeader(nameof(HeaderDocument.OfxHeader))}:{doc.OfxHeader}");
            header.AppendLine($"{Entity.GetHeader(nameof(HeaderDocument.Data))}:{doc.Data}");
            header.AppendLine($"{Entity.GetHeader(nameof(HeaderDocument.Version))}:{doc.Version}");
            header.AppendLine($"{Entity.GetHeader(nameof(HeaderDocument.Security))}:{doc.Security}");
            header.AppendLine($"{Entity.GetHeader(nameof(HeaderDocument.Encoding))}:{doc.Encoding}");
            header.AppendLine($"{Entity.GetHeader(nameof(HeaderDocument.Charset))}:{doc.Charset}");
            header.AppendLine($"{Entity.GetHeader(nameof(HeaderDocument.Compression))}:{doc.Compression}");
            header.AppendLine($"{Entity.GetHeader(nameof(HeaderDocument.OldFileUid))}:{doc.OldFileUid}");
            header.AppendLine($"{Entity.GetHeader(nameof(HeaderDocument.NewFileUid))}:{doc.NewFileUid}");
            header.AppendLine("");

            return header;
        }

        private StringBuilder BuildResponse(ResponseDocument doc)
        {
            var response = new StringBuilder();


            response.AppendLine($"<{Entity.GetElement<ResponseDocument>()}>");

            //
            if (doc.SignonResponseMessageSetV1 != null)
                response.Append(new SIGNONMSGSRSV1().Build(doc.SignonResponseMessageSetV1));

            //
            if (doc.BankResponseMessageSetV1 != null)
                response.Append(new BANKMSGSRSV1().Build(doc.BankResponseMessageSetV1));

            response.AppendLine($"</{Entity.GetElement<ResponseDocument>()}>");

            return response;
        }
    }
}
