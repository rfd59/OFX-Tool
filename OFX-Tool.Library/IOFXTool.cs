using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library
{
    public interface IOFXTool
    {
        Extract GenerateExtract(string ofxSourceFile);
    }
}