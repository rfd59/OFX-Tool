using System.Text;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal abstract class ElementAbstract<T>
    {
        // Build variables
        protected int _level;
        protected StringBuilder _build;
        // Load variables
        protected string _field = "";
        protected T _load;

        internal StringBuilder Build(T doc, int level = 0)
        {
            _level = level;

            _build = new StringBuilder();
            _build.AppendLine(BuildToFile.WriteStartObject(Entity.GetElementClass<T>().Name, _level));
            BuildElement(doc);
            _build.AppendLine(BuildToFile.WriteEndObject(Entity.GetElementClass<T>().Name, _level));

            return _build;
        }

        protected abstract void BuildElement(T doc);

        internal T Load(XmlTextReader xmlReader)
        {
            var obj = Activator.CreateInstance(typeof(T));
            if (obj == null)
                throw new NullReferenceException();
            _load = (T)obj;

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals(Entity.GetElementClass<T>().Name))
                    break;

                if (xmlReader.NodeType == XmlNodeType.Element)
                    _field = xmlReader.Name;

                LoadElement(xmlReader);
            }

            return _load;
        }

        protected abstract void LoadElement(XmlTextReader xmlReader);
    }
}