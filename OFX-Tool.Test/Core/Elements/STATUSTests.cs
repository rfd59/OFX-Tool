using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Enums;
using System;
using System.IO;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements.Tests
{
    [TestClass()]
    public class STATUSTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var doc = new Status() { Code = "2", Severity = SeverityEnum.ERROR };
            var expected = $"<STATUS><CODE>{doc.Code}<SEVERITY>{doc.Severity}</STATUS>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Full()
        {
            var doc = new Status() { Code = "2", Message = "My Message", Severity = SeverityEnum.ERROR };
            var expected = $"<STATUS><CODE>{doc.Code}<MESSAGE>{doc.Message}<SEVERITY>{doc.Severity}</STATUS>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Empty()
        {
            var doc = new Status();
            var expected = $"<STATUS></STATUS>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(Status doc, string expected)
        {
            var build = new STATUS().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var expected = new Status() { Code = "2", Severity = SeverityEnum.ERROR };
            var xml = $"<STATUS><CODE>{ expected.Code}</CODE><SEVERITY>{ expected.Severity}</SEVERITY></STATUS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Full()
        {
            var expected = new Status() { Code = "2", Message = "My Message", Severity = SeverityEnum.ERROR };
            var xml = $"<STATUS><CODE>{ expected.Code}</CODE><MESSAGE>{ expected.Message}</MESSAGE><SEVERITY>{ expected.Severity}</SEVERITY></STATUS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Empty()
        {
            var expected = new Status();
            var xml = $"<STATUS></STATUS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<STATUS><UNKNOWN>My unknown value</UNKNOWN></STATUS>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, Status? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new STATUS().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}