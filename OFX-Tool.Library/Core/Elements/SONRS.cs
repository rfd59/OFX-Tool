﻿using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Signon;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal class SONRS : ElementAbstract<SignonResponse>
    {
        protected override void BuildElement(SignonResponse doc)
        {
            if (doc.Status != null)
                _build.Append(new STATUS().Build(doc.Status, _level + 1));
            if (doc.ServerDate != null)
                _build.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<SignonResponse>(nameof(SignonResponse.ServerDate)).Name, doc.ServerDate, _level));
            if (doc.Language != null)
                _build.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<SignonResponse>(nameof(SignonResponse.Language)).Name, doc.Language.ToString(), _level));
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            // STATUS element object
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElementClass<Status>().Name))
            {
                _load.Status = new STATUS().Load(xmlReader);
            }

            if (xmlReader.NodeType == XmlNodeType.Text)
            {
                if (_field == Entity.GetElementProperty<SignonResponse>(nameof(SignonResponse.ServerDate)).Name)
                    _load.ServerDate = xmlReader.Value;
                else if (_field == Entity.GetElementProperty<SignonResponse>(nameof(SignonResponse.Language)).Name)
                    _load.Language = (LanguageEnum)Enum.Parse(typeof(LanguageEnum), xmlReader.Value);
                else
                    throw new InvalidOperationException($"Unexpected value! [{_field}]");
            }
        }
    }
}