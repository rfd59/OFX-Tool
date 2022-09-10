using RFD.OFXTool.Library.Entities;
using System.Text;

namespace RFD.OFXTool.Library.Core.Build
{
    internal abstract class BuildAbstract<T>
    {
        internal StringBuilder Element { get; set; }
        protected int Level;

        internal BuildAbstract(T doc, int level = 0)
        {
            Level = level;

            Element = new StringBuilder();
            Element.AppendLine(BuildToFile.WriteStartObject(Entity.GetElementClass<T>().Name, Level));
            BuildElement(doc);
            Element.AppendLine(BuildToFile.WriteEndObject(Entity.GetElementClass<T>().Name, Level));
        }

        protected abstract void BuildElement(T doc);
    }
}