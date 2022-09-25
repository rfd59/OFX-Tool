namespace RFD.OFXTool.Library.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal class Header : Attribute
    {
        internal string Name { get; }

        internal Header(string name)
        {
            Name = name;
        }
    }
}
