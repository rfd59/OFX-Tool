using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace RFD.OFXTool.Test.Core
{
    [TestClass]
    public class ExportToXMLTests
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
            new ExportToXML("TestFiles/UnitTest1.ofx", "InvalidXmlName.txt");
        }

        [TestMethod]
        [DataRow("TestFiles/UnitTest1.ofx")]
        [DataRow("TestFiles/UnitTest2.ofx")]
        public void ExportToXML(string ofxFile)
        {
            var xml = new ExportToXML(ofxFile);
            Assert.IsTrue(File.Exists(xml.XmlFile));

            var file = xml.XmlFile;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add("", "Ofx.xsd");
            settings.ValidationType = ValidationType.Schema;

            using (var reader = XmlReader.Create(new StreamReader(file), settings))
            {
                var document = new XmlDocument();
                document.Load(reader);
            }
        }

    }
}
