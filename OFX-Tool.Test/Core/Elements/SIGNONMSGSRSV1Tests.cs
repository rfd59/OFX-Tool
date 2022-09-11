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
    public class SIGNONMSGSRSV1Tests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var doc = new SignonResponseMessageSetV1() { SignonResponse = new SignonResponse()};
            var expected = $"<SIGNONMSGSRSV1><SONRS></SONRS></SIGNONMSGSRSV1>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(SignonResponseMessageSetV1 doc, string expected)
        {
            var build = new SIGNONMSGSRSV1().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var expected = new SignonResponseMessageSetV1() { SignonResponse = new SignonResponse() };
            var xml = $"<SIGNONMSGSRSV1><SONRS></SONRS></SIGNONMSGSRSV1>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<SIGNONMSGSRSV1><UNKNOWN>My unknown value</UNKNOWN></SIGNONMSGSRSV1>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, SignonResponseMessageSetV1? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new SIGNONMSGSRSV1().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}