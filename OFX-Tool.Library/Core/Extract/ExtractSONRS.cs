using RFD.OFXTool.Library.Ofx;
using RFD.OFXTool.Library.Ofx.Signon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractSONRS
    {
        internal SignonResponse Element { get; }

        internal ExtractSONRS(XmlTextReader xmlReader)
        {
            Element = new SignonResponse();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("SONRS"))
                {
                    break;
                }

                // STATUS element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("STATUS"))
                {
                    Element.Status = new ExtractSTATUS(xmlReader).Element;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    switch (myField)
                    {
                        case "DTSERVER":
                            Element.ServerDate = xmlReader.Value;
                            break;
                        case "LANGUAGE":
                            Element.Language = (LanguageEnum)Enum.Parse(typeof(LanguageEnum), xmlReader.Value);
                            break;
                    }
                }
            }
        }
    }
}
