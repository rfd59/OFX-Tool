using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using RFD.OFXTool.Library.Entities.Signon;
using RFD.OFXTool.Library.Enums;
using System;
using System.IO;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements.Tests
{
    [TestClass()]
    public class STMTRSTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var doc = new StatementResponse() { Currency= CurrencyEnum.USD};
            var expected = $"<STMTRS><CURDEF>{doc.Currency}</STMTRS>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Full()
        {
            var doc = new StatementResponse() { Currency = CurrencyEnum.USD, AvailableBalance= new AvailableBalance(), BankAccountFrom= new BankAccount(), LedgerBalance=new LedgerBalance(), BankTransactionList =new BankTransactionList() };
            var expected = $"<STMTRS><CURDEF>{doc.Currency}<BANKACCTFROM></BANKACCTFROM><BANKTRANLIST></BANKTRANLIST><LEDGERBAL></LEDGERBAL><AVAILBAL></AVAILBAL></STMTRS>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Empty()
        {
            var doc = new StatementResponse();
            var expected = $"<STMTRS></STMTRS>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(StatementResponse doc, string expected)
        {
            var build = new STMTRS().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var expected = new StatementResponse() { Currency = CurrencyEnum.USD };
            var xml = $"<STMTRS><CURDEF>{ expected.Currency}</CURDEF></STMTRS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Full()
        {
            var expected = new StatementResponse() { Currency = CurrencyEnum.USD, AvailableBalance = new AvailableBalance(), BankAccountFrom = new BankAccount(), LedgerBalance = new LedgerBalance(), BankTransactionList = new BankTransactionList() };
            var xml = $"<STMTRS><CURDEF>{expected.Currency}</CURDEF><BANKACCTFROM></BANKACCTFROM><BANKTRANLIST></BANKTRANLIST><LEDGERBAL></LEDGERBAL><AVAILBAL></AVAILBAL></STMTRS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Empty()
        {
            var expected = new StatementResponse();
            var xml = $"<STMTRS></STMTRS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<STMTRS><UNKNOWN>My unknown value</UNKNOWN></STMTRS>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, StatementResponse? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new STMTRS().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}