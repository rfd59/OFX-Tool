namespace RFD.OFXTool.Library.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class Element : Attribute
    {
        public string Name { get; }
        public ElementTypeEnum Type { get; }

        public Element(string name, ElementTypeEnum type)
        {
            Name = name;
            Type = type;
        }
    }
}
