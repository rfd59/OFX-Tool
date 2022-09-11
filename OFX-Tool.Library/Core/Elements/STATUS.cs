using RFD.OFXTool.Library.Entities;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal class STATUS : ElementAbstract<Status>
    {
        protected override void BuildElement(Status doc)
        {
            if (doc.Code != null)
                _build.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<Status>(nameof(Status.Code)).Name, doc.Code, _level));
            if (doc.Severity != null)
                _build.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<Status>(nameof(Status.Severity)).Name, doc.Severity.ToString(), _level));
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            if (xmlReader.NodeType == XmlNodeType.Text)
            {
                if (_field == Entity.GetElementProperty<Status>(nameof(Status.Code)).Name)
                    _load.Code = xmlReader.Value;
                else if (_field == Entity.GetElementProperty<Status>(nameof(Status.Severity)).Name)
                    _load.Severity = (SeverityEnum)Enum.Parse(typeof(SeverityEnum), xmlReader.Value);
                else
                    throw new InvalidOperationException($"Unexpected value! [{_field}]");
            }
        }
    }
}