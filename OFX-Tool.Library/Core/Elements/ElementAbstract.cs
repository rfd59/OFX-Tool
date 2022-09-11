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
            _build.AppendLine(WriteStartObject<T>(_level));
            BuildElement(doc);
            _build.AppendLine(WriteEndObject<T>(_level));

            return _build;
        }

        protected abstract void BuildElement(T doc);

        internal T Load(XmlTextReader xmlReader)
        {
            _load = (T)Activator.CreateInstance(typeof(T));

            while (xmlReader.Read())
            {
                // End of the element
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals(Entity.GetElement<T>()))
                    break;

                // Get the XML field name
                if (xmlReader.NodeType == XmlNodeType.Element)
                    _field = xmlReader.Name;

                LoadElement(xmlReader);
            }

            return _load;
        }

        protected abstract void LoadElement(XmlTextReader xmlReader);


        protected string WriteStartObject<O>(int level = 0)
        {
            return $"{tabs(level)}<{Entity.GetElement<O>()}>";
        }

        protected string WriteEndObject<O>(int level = 0)
        {
            return $"{tabs(level)}</{Entity.GetElement<O>()}>";
        }

        protected string WriteProperty<O>(string property, Object value, int level = 0)
        {
            return $"{tabs(level)}\t<{Entity.GetElement<O>(property)}>{value.ToString()}";
        }

        private string tabs(int level)
        {
            var t = "";
            for (int i = 0; i < level; i++)
            {
                t += "\t";
            }

            return t;
        }
    }
}