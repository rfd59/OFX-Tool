using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Core;
using System;
using System.IO;
using System.Threading;
using System.Xml;

namespace RFD.OFXTool.Test.Core
{
    [TestClass]
    public class ExportToXmlTests
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFound()
        {
            new ExportToXml("FileNotFound.ofx");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidXmlName()
        {
            new ExportToXml("TestFiles/ExportToXmlTest1.ofx", "InvalidXmlName.txt");
        }

        [TestMethod]
        [DataRow("TestFiles/ExportToXmlTest1.ofx")]
        //[DataRow("TestFiles/UnitTest2.ofx")]
        public void ExportToXML(string ofxFile)
        {
            var xml = new ExportToXml(ofxFile);
            Assert.AreEqual(ofxFile, xml.OfxFile);
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

        [TestMethod]
        public void XmlExist()
        {
            var xml = new ExportToXml("TestFiles/ExportToXmlTest1.ofx");
            var writed = File.GetLastWriteTime(xml.XmlFile);

            // To be sure that not be in the same second
            Thread.Sleep(1000);

            xml = new ExportToXml("TestFiles/ExportToXmlTest1.ofx");
            Assert.IsFalse(writed.Equals(File.GetLastWriteTime(xml.XmlFile)));
        }

    }
}
