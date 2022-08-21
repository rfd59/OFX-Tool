using RFD.OFXTool.Library.Core;
using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library
{
    public class OFXTool : IOFXTool
    {
        public static ResponseDocument GetExtract(string ofxSourceFile)
        {
            return new OFXTool().Extract(ofxSourceFile);
        }

        public ResponseDocument Extract(string ofxSourceFile)
        {
            // Translating to XML file
            var xml = new ExportToXml(ofxSourceFile);

            // Load the XML file to a OFX document
            return new LoadFromXml(xml.XmlFile).OfxDocument;
        }
    }
}
