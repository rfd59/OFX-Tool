using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities.Bank;
using RFD.OFXTool.Library.Enums;
using System;
using System.IO;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements.Tests
{
    [TestClass()]
    public class STMTTRNTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var doc = new StatementTransaction() { TransactionType = TransactionEnum.CREDIT, PostedDate = "20220602", UserDate = "20220606", TransactionAmount = "123.45", FinancialInstitutionTransactionId = "AZ3ERT5GFD", Memo = "VIR ..." };
            var expected = $"<STMTTRN><TRNTYPE>{doc.TransactionType}<DTUSER>{doc.UserDate}<DTPOSTED>{doc.PostedDate}<TRNAMT>{doc.TransactionAmount}<FITID>{doc.FinancialInstitutionTransactionId}<MEMO>{doc.Memo}</STMTTRN>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Full()
        {
            var doc = new StatementTransaction() { TransactionType = TransactionEnum.CREDIT, PostedDate = "20220602", UserDate = "20220606", TransactionAmount = "123.45", FinancialInstitutionTransactionId = "AZ3ERT5GFD", Memo = "VIR ...", CheckNumber = "123456", AvailableDate = "20220123", CorrectFinancialInstitutionTransactionId = "987654", ExtendedName = "azerty", Name = "MyName", PayeeId = "456321", ReferenceNumber = "29716", ServerTransactionId = "31796", StandardIndustrialCode = "0001" };
            var expected = $"<STMTTRN><TRNTYPE>{doc.TransactionType}<DTUSER>{doc.UserDate}<DTPOSTED>{doc.PostedDate}<TRNAMT>{doc.TransactionAmount}<FITID>{doc.FinancialInstitutionTransactionId}<CHECKNUM>{doc.CheckNumber}<MEMO>{doc.Memo}<NAME>{doc.Name}<PAYEEID>{doc.PayeeId}<SIC>{doc.StandardIndustrialCode}<EXTDNAME>{doc.ExtendedName}<REFNUM>{doc.ReferenceNumber}<SRVRTID>{doc.ServerTransactionId}<CORRECTFITID>{doc.CorrectFinancialInstitutionTransactionId}<DTAVAIL>{doc.AvailableDate}</STMTTRN>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Empty()
        {
            var doc = new StatementTransaction();
            var expected = $"<STMTTRN></STMTTRN>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(StatementTransaction doc, string expected)
        {
            var build = new STMTTRN().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var expected = new StatementTransaction() { TransactionType = TransactionEnum.CREDIT, PostedDate = "20220602", UserDate = "20220606", TransactionAmount = "123.45", FinancialInstitutionTransactionId = "AZ3ERT5GFD", Memo = "VIR ..." };
            var xml = $"<STMTTRN><TRNTYPE>{expected.TransactionType}</TRNTYPE><DTPOSTED>{expected.PostedDate}</DTPOSTED><DTUSER>{expected.UserDate}</DTUSER><TRNAMT>{expected.TransactionAmount}</TRNAMT><FITID>{expected.FinancialInstitutionTransactionId}</FITID><MEMO>{expected.Memo}</MEMO></STMTTRN>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Full()
        {
            var expected = new StatementTransaction() { TransactionType = TransactionEnum.CREDIT, PostedDate = "20220602", UserDate = "20220606", TransactionAmount = "123.45", FinancialInstitutionTransactionId = "AZ3ERT5GFD", Memo = "VIR ...", CheckNumber = "123456", AvailableDate = "20220123", CorrectFinancialInstitutionTransactionId = "987654", ExtendedName = "azerty", Name = "MyName", PayeeId = "456321", ReferenceNumber = "29716", ServerTransactionId = "31796", StandardIndustrialCode = "0001" };
            var xml = $"<STMTTRN><TRNTYPE>{expected.TransactionType}</TRNTYPE><DTUSER>{expected.UserDate}</DTUSER><DTPOSTED>{expected.PostedDate}</DTPOSTED><TRNAMT>{expected.TransactionAmount}</TRNAMT><FITID>{expected.FinancialInstitutionTransactionId}</FITID><CHECKNUM>{expected.CheckNumber}</CHECKNUM><MEMO>{expected.Memo}</MEMO><NAME>{expected.Name}</NAME><PAYEEID>{expected.PayeeId}</PAYEEID><SIC>{expected.StandardIndustrialCode}</SIC><EXTDNAME>{expected.ExtendedName}</EXTDNAME><REFNUM>{expected.ReferenceNumber}</REFNUM><SRVRTID>{expected.ServerTransactionId}</SRVRTID><CORRECTFITID>{expected.CorrectFinancialInstitutionTransactionId}</CORRECTFITID><DTAVAIL>{expected.AvailableDate}</DTAVAIL></STMTTRN>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Empty()
        {
            var expected = new StatementTransaction();
            var xml = $"<STMTTRN></STMTTRN>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<STMTTRN><UNKNOWN>My unknown value</UNKNOWN></STMTTRN>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, StatementTransaction? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new STMTTRN().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}