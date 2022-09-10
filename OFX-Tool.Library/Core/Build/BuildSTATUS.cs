using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library.Core.Build
{
    internal class BuildSTATUS : BuildAbstract<Status>
    {
        public BuildSTATUS(Status doc, int level = 0) : base(doc, level)
        {
        }

        protected override void BuildElement(Status doc)
        {
            if (doc.Code != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<Status>(nameof(Status.Code)).Name, doc.Code, Level));
            if (doc.Severity != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<Status>(nameof(Status.Severity)).Name, doc.Severity.ToString(), Level));
        }
    }
}