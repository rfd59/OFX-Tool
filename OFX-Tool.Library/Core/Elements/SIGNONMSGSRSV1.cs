using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Signon;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal class SIGNONMSGSRSV1 : ElementAbstract<SignonResponseMessageSetV1>
    {
        protected override void BuildElement(SignonResponseMessageSetV1 doc)
        {
            if (doc.SignonResponse != null)
                _build.Append(new SONRS().Build(doc.SignonResponse, _level + 1));
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            // SONRS element object
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<SignonResponse>()))
                _load.SignonResponse = new SONRS().Load(xmlReader);
        }
    }
}