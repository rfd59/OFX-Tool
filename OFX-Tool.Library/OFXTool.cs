using RFD.OFXTool.Library.Core;
using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library
{
    public class OfxTool : IOfxTool
    {
        public Ofx? Ofx { get; set; }

        public OfxTool() { }

        public OfxTool(string ofxSourceFile) {
            Load(ofxSourceFile);
        }

        public void Load(string ofxSourceFile)
        {
            if (File.Exists(ofxSourceFile))
                Ofx =  new Load(ofxSourceFile).Ofx;
            else
                throw new OFXToolException($"The OFX file '{ofxSourceFile}' doesn't exist!");
        }
        public void Build(string ofxTargetFile)
        {
            if (Ofx != null)
                new Build(Ofx, ofxTargetFile);
            else
                throw new OFXToolException($"The OFX object is null!");
        }

        public static Ofx? Get(string ofxSourceFile)
        {
            return new OfxTool(ofxSourceFile).Ofx;
        }

        public static void Set(Ofx ofx, string ofxTargetFile)
        {
            new OfxTool() { Ofx=ofx}.Build(ofxTargetFile);
        }

    }
}
