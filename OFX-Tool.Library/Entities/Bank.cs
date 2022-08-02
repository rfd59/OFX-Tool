namespace RFD.OFXTool.Library.Entities
{
    public class Bank
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public Bank(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
