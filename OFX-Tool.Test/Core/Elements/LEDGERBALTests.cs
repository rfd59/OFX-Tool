using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Enums;
using System;
using System.IO;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements.Tests
{
    [TestClass()]
    public class LEDGERBALTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var doc = new LedgerBalance() { DateAsOf="20220911000000" };
            var expected = $"<LEDGERBAL><DTASOF>{doc.DateAsOf}</LEDGERBAL>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Full()
        {
            var doc = new LedgerBalance() { DateAsOf = "20220911000000", BalanceAmount="0.00" };
            var expected = $"<LEDGERBAL><BALAMT>{doc.BalanceAmount}<DTASOF>{doc.DateAsOf}</LEDGERBAL>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Empty()
        {
            var doc = new LedgerBalance();
            var expected = $"<LEDGERBAL></LEDGERBAL>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(LedgerBalance doc, string expected)
        {
            var build = new LEDGERBAL().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var expected = new LedgerBalance() { BalanceAmount="100.00" };
            var xml = $"<LEDGERBAL><BALAMT>{ expected.BalanceAmount}</BALAMT></LEDGERBAL>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Full()
        {
            var expected = new LedgerBalance() { BalanceAmount = "100.00", DateAsOf="20220909123456" };
            var xml = $"<LEDGERBAL><BALAMT>{ expected.BalanceAmount}</BALAMT><DTASOF>{ expected.DateAsOf}</DTASOF></LEDGERBAL>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Empty()
        {
            var expected = new LedgerBalance();
            var xml = $"<LEDGERBAL></LEDGERBAL>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<LEDGERBAL><UNKNOWN>My unknown value</UNKNOWN></LEDGERBAL>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, LedgerBalance? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new LEDGERBAL().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}