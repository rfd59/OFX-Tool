using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Test.Core
{
    [TestClass]
    public class ExportToXMLTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFound()
        {
            new ExportToXML("FileNotFound.ofx");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidXmlName()
        {
            new ExportToXML("UnitTest1.ofx", "InvalidXmlName.txt");
        }
    }
}
