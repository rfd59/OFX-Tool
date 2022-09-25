using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library
{
    public interface IOfxTool
    {
        public void Load(string ofxSourceFile);

        public void Build(string ofxTargetFile);
    }
}