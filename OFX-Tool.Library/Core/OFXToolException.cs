namespace RFD.OFXTool.Library.Core
{
    public class OFXToolException : Exception
    {
        public OFXToolException()
        {
        }

        public OFXToolException(string message) : base(message)
        {
        }

        public OFXToolException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
