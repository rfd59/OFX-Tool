using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library
{
    public interface IOfxTool
    {
        public Ofx Load(string ofxSourceFile);

        public void Build(Ofx ofx, string ofxTargetFile);
    }
}