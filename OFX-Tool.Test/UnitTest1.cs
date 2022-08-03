using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library;
using System.IO;

namespace RFD.OFXTool.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestMethod1()
        {
            OFXTool.Library.OFXTool.GetExtract("test.file");
        }
    }
}