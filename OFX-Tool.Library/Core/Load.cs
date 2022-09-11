using RFD.OFXTool.Library.Core.Elements;
using RFD.OFXTool.Library.Entities;
using System.Text;
using System.Xml;

namespace RFD.OFXTool.Library.Core
{
    internal class Load
    {
        internal string OfxFile { get; }
        internal Ofx Ofx { get; }

        internal Load(string ofxSourceFile)
        {
            OfxFile = ofxSourceFile;
            Ofx = new Ofx();
            
            try
            {
                // Load OFX document
                Ofx.Header = LoadHeader();
                Ofx.Response = LoadResponse();
            } catch (Exception e)
            {
                throw new OFXToolException($"Invalid OFX file! [{e.Message}]", e);
            }
        }

        private HeaderDocument LoadHeader()
        {
            string line;
            HeaderDocument header;

            using (var sr = new StreamReader(OfxFile, Encoding.Default))
            {
                header = new HeaderDocument();

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (! (line.StartsWith("<") || line.Length == 0) )
                    {
                        var setting = line.Split(":");
                        if (setting[0] == Entity.GetHeader(nameof(HeaderDocument.OfxHeader)))
                            header.OfxHeader = setting[1];
                        else if (setting[0] == Entity.GetHeader(nameof(HeaderDocument.Data)))
                            header.Data = setting[1];
                        else if (setting[0] == Entity.GetHeader(nameof(HeaderDocument.Version)))
                            header.Version = setting[1];
                        else if (setting[0] == Entity.GetHeader(nameof(HeaderDocument.Security)))
                            header.Security = setting[1];
                        else if (setting[0] == Entity.GetHeader(nameof(HeaderDocument.Encoding)))
                            header.Encoding = setting[1];
                        else if (setting[0] == Entity.GetHeader(nameof(HeaderDocument.Charset)))
                            header.Charset = setting[1];
                        else if (setting[0] == Entity.GetHeader(nameof(HeaderDocument.Compression)))
                            header.Compression = setting[1];
                        else if (setting[0] == Entity.GetHeader(nameof(HeaderDocument.OldFileUid)))
                            header.OldFileUid = setting[1];
                        else if (setting[0] == Entity.GetHeader(nameof(HeaderDocument.NewFileUid)))
                            header.NewFileUid = setting[1];
                        else
                            throw new InvalidOperationException($"Unexpected header! [{setting[0]}]");
                    }
                }
            }

            return header;
        }

        private ResponseDocument LoadResponse()
        {
            var response = new ResponseDocument();
            // Translating to XML file and parse the XML
            var xml = new ExportToXml(OfxFile);

            using (var xmlReader = new XmlTextReader(xml.XmlFile))
            {
                
                while (xmlReader.Read())
                {
                    //
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<SignonResponseMessageSetV1>()))
                        response.SignonResponseMessageSetV1 = new SIGNONMSGSRSV1().Load(xmlReader);

                    //
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<BankResponseMessageSetV1>()))
                        response.BankResponseMessageSetV1 = new BANKMSGSRSV1().Load(xmlReader);
                }
            }

            return response;
        }
    }
}