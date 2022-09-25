using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities.Bank;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements.Tests
{
    [TestClass()]
    public class BANKTRANLISTTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var doc = new BankTransactionList() { StartDate = "20220911000000", EndDate = "20230911000000" };
            var expected = $"<BANKTRANLIST><DTSTART>{doc.StartDate}<DTEND>{doc.EndDate}</BANKTRANLIST>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Full()
        {
            var st = new List<StatementTransaction>();
            st.Add(new StatementTransaction());

            var doc = new BankTransactionList() { StartDate = "20220911000000", EndDate = "20230911000000", StatementTransactions = st };
            var expected = $"<BANKTRANLIST><DTSTART>{doc.StartDate}<DTEND>{doc.EndDate}<STMTTRN></STMTTRN></BANKTRANLIST>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Empty()
        {
            var doc = new BankTransactionList();
            var expected = $"<BANKTRANLIST></BANKTRANLIST>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(BankTransactionList doc, string expected)
        {
            var build = new BANKTRANLIST().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var expected = new BankTransactionList() { StartDate = "20220911000000", EndDate = "20230911000000" };
            var xml = $"<BANKTRANLIST><DTSTART>{ expected.StartDate}</DTSTART><DTEND>{ expected.EndDate}</DTEND></BANKTRANLIST>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Full()
        {
            var st = new List<StatementTransaction>();
            st.Add(new StatementTransaction());

            var expected = new BankTransactionList() { StartDate = "20220911000000", EndDate = "20230911000000", StatementTransactions = st };
            var xml = $"<BANKTRANLIST><DTSTART>{ expected.StartDate}</DTSTART><DTEND>{ expected.EndDate}</DTEND><STMTTRN></STMTTRN></BANKTRANLIST>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Empty()
        {
            var expected = new BankTransactionList();
            var xml = $"<BANKTRANLIST></BANKTRANLIST>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<BANKTRANLIST><UNKNOWN>My unknown value</UNKNOWN></BANKTRANLIST>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, BankTransactionList? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new BANKTRANLIST().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}