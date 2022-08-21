using RFD.OFXTool.Library.Ofx;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractSTATUS
    {
        internal Status Element { get; }

        internal ExtractSTATUS(XmlTextReader xmlReader)
        {
            Element = new Status();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("STATUS"))
                {
                    break;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    switch (myField)
                    {
                        case "CODE":
                            Element.Code = xmlReader.Value;
                            break;
                        case "SEVERITY":
                            Element.Severity = (SeverityEnum)Enum.Parse(typeof(SeverityEnum), xmlReader.Value);
                            break;
                    }
                }
            }
        }
    }
}
