using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Signon;
using System.Text;

namespace RFD.OFXTool.Library.Core.Build
{
    internal class BuildSONRS : BuildAbstract<SignonResponse>
    {
        public BuildSONRS(SignonResponse doc, int level = 0) : base(doc, level)
        {
        }

        protected override void BuildElement(SignonResponse doc)
        {
            if (doc.Status != null)
                Element.Append(new BuildSTATUS(doc.Status, Level + 1).Element);
            if (doc.ServerDate != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<SignonResponse>(nameof(SignonResponse.ServerDate)).Name, doc.ServerDate, Level));
            if (doc.Language != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<SignonResponse>(nameof(SignonResponse.Language)).Name, doc.Language.ToString(), Level));
        }
    }
}