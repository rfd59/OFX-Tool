using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Signon;
using RFD.OFXTool.Library.Enums;
using System;
using System.IO;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements.Tests
{
    [TestClass()]
    public class SONRSTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var doc = new SignonResponse() { ServerDate = "20220911000000", Language = LanguageEnum.FRA };
            var expected = $"<SONRS><DTSERVER>{doc.ServerDate}<LANGUAGE>{doc.Language}</SONRS>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Full()
        {
            var doc = new SignonResponse() { ServerDate = "20220911000000", Language = LanguageEnum.FRA, Status = new Status() };
            var expected = $"<SONRS><STATUS></STATUS><DTSERVER>{doc.ServerDate}<LANGUAGE>{doc.Language}</SONRS>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Empty()
        {
            var doc = new SignonResponse();
            var expected = $"<SONRS></SONRS>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(SignonResponse doc, string expected)
        {
            var build = new SONRS().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var expected = new SignonResponse() { ServerDate = "20220911000000", Language = LanguageEnum.FRA };
            var xml = $"<SONRS><DTSERVER>{ expected.ServerDate}</DTSERVER><LANGUAGE>{ expected.Language}</LANGUAGE></SONRS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Full()
        {
            var expected = new SignonResponse() { ServerDate = "20220911000000", Language = LanguageEnum.FRA, Status = new Status() };
            var xml = $"<SONRS><STATUS></STATUS><DTSERVER>{ expected.ServerDate}</DTSERVER><LANGUAGE>{ expected.Language}</LANGUAGE></SONRS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Empty()
        {
            var expected = new SignonResponse();
            var xml = $"<SONRS></SONRS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<SONRS><UNKNOWN>My unknown value</UNKNOWN></SONRS>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, SignonResponse? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new SONRS().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}