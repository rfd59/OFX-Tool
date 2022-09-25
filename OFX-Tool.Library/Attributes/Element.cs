namespace RFD.OFXTool.Library.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    internal class Element : Attribute
    {
        internal string Name { get; }

        internal Element(string name)
        {
            Name = name;
        }
    }
}
