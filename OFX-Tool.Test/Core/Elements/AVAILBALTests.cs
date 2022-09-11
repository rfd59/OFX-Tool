using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities;
using System;
using System.IO;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements.Tests
{
    [TestClass()]
    public class AVAILBALTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var doc = new AvailableBalance() { DateAsOf = "20220911000000" };
            var expected = $"<AVAILBAL><DTASOF>{doc.DateAsOf}</AVAILBAL>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Full()
        {
            var doc = new AvailableBalance() { DateAsOf = "20220911000000", BalanceAmount = "0.00" };
            var expected = $"<AVAILBAL><BALAMT>{doc.BalanceAmount}<DTASOF>{doc.DateAsOf}</AVAILBAL>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Empty()
        {
            var doc = new AvailableBalance();
            var expected = $"<AVAILBAL></AVAILBAL>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(AvailableBalance doc, string expected)
        {
            var build = new AVAILBAL().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var expected = new AvailableBalance() { BalanceAmount = "100.00" };
            var xml = $"<AVAILBAL><BALAMT>{ expected.BalanceAmount}</BALAMT></AVAILBAL>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Full()
        {
            var expected = new AvailableBalance() { BalanceAmount = "100.00", DateAsOf = "20220909123456" };
            var xml = $"<AVAILBAL><BALAMT>{ expected.BalanceAmount}</BALAMT><DTASOF>{ expected.DateAsOf}</DTASOF></AVAILBAL>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Empty()
        {
            var expected = new AvailableBalance();
            var xml = $"<AVAILBAL></AVAILBAL>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<AVAILBAL><UNKNOWN>My unknown value</UNKNOWN></AVAILBAL>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, AvailableBalance? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new AVAILBAL().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}