using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Enums;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal class STATUS : ElementAbstract<Status>
    {
        protected override void BuildElement(Status doc)
        {
            if (doc.Code != null)
                _build.AppendLine(WriteProperty<Status>(nameof(Status.Code), doc.Code, _level));
            if (doc.Message != null)
                _build.AppendLine(WriteProperty<Status>(nameof(Status.Message), doc.Message, _level));
            if (doc.Severity != null)
                _build.AppendLine(WriteProperty<Status>(nameof(Status.Severity), doc.Severity, _level));
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            if (xmlReader.NodeType == XmlNodeType.Text)
            {
                if (_field == Entity.GetElement<Status>(nameof(Status.Code)))
                    _load.Code = xmlReader.Value;
                else if (_field == Entity.GetElement<Status>(nameof(Status.Message)))
                    _load.Message = xmlReader.Value;
                else if (_field == Entity.GetElement<Status>(nameof(Status.Severity)))
                    _load.Severity = (SeverityEnum)Enum.Parse(typeof(SeverityEnum), xmlReader.Value);
                else
                    throw new InvalidOperationException($"Unexpected value! [{_field}]");
            }
        }
    }
}