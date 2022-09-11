namespace RFD.OFXTool.Library.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class Header : Attribute
    {
        public string Name { get; }

        public Header(string name)
        {
            Name = name;
        }
    }
}
