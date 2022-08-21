using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library
{
    public interface IOFXTool
    {
        ResponseDocument Extract(string ofxSourceFile);
    }
}