using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Signon;
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
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals(Entity.GetElementClass<SignonResponse>().Name))
                {
                    break;
                }

                // STATUS element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElementClass<Status>().Name))
                {
                    Element.Status = new ExtractSTATUS(xmlReader).Element;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    if (myField == Entity.GetElementProperty<SignonResponse>(nameof(SignonResponse.ServerDate)).Name)
                        Element.ServerDate = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<SignonResponse>(nameof(SignonResponse.Language)).Name)
                        Element.Language = (LanguageEnum)Enum.Parse(typeof(LanguageEnum), xmlReader.Value);
                    else
                        throw new InvalidOperationException($"Unexpected value! [{myField}]");
                }
            }
        }
    }
}
