using RFD.OFXTool.Library.Core;
using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library
{
    public class OfxTool : IOfxTool
    {
        public void Build(Ofx ofx, string ofxTargetFile)
        {
            if (ofx != null)
                new Build(ofx, ofxTargetFile);
            else
                throw new OFXToolException($"The OFX object is null!");
        }

        public Ofx Load(string ofxSourceFile)
        {
            if (File.Exists(ofxSourceFile))
                return new Load(ofxSourceFile).Ofx;
            else
                throw new OFXToolException($"The OFX file '{ofxSourceFile}' doesn't exist!");
        }

        public static Ofx Get(string ofxSourceFile)
        {
            return new OfxTool().Load(ofxSourceFile);
        }

        public static void Set(Ofx ofx, string ofxTargetFile)
        {
            new OfxTool().Build(ofx, ofxTargetFile);
        }

    }
}
