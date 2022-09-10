using RFD.OFXTool.Library.Entities;
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
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals(Entity.GetElementClass<Status>().Name))
                {
                    break;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    if (myField == Entity.GetElementProperty<Status>(nameof(Status.Code)).Name)
                        Element.Code = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<Status>(nameof(Status.Severity)).Name)
                        Element.Severity = (SeverityEnum)Enum.Parse(typeof(SeverityEnum), xmlReader.Value);
                    else
                        throw new InvalidOperationException($"Unexpected value! [{myField}]");
                }
            }
        }
    }
}
