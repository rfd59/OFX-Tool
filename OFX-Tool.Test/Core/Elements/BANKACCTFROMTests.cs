using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities.Bank;
using RFD.OFXTool.Library.Enums;
using System;
using System.IO;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements.Tests
{
    [TestClass()]
    public class BANKACCTFROMTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var doc = new BankAccount() { BankId = "12345", BranchId = "67890", AccountId = "987456321", AccountType = AccountEnum.MONEYMRKT };
            var expected = $"<BANKACCTFROM><BANKID>{doc.BankId}<BRANCHID>{doc.BranchId}<ACCTID>{doc.AccountId}<ACCTTYPE>{doc.AccountType}</BANKACCTFROM>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Full()
        {
            var doc = new BankAccount() { BankId = "12345", BranchId = "67890", AccountId = "987456321", AccountType = AccountEnum.MONEYMRKT, AccountKey = "321456987" };
            var expected = $"<BANKACCTFROM><BANKID>{doc.BankId}<BRANCHID>{doc.BranchId}<ACCTID>{doc.AccountId}<ACCTTYPE>{doc.AccountType}<ACCTKEY>{doc.AccountKey}</BANKACCTFROM>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Empty()
        {
            var doc = new BankAccount();
            var expected = $"<BANKACCTFROM></BANKACCTFROM>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(BankAccount doc, string expected)
        {
            var build = new BANKACCTFROM().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var expected = new BankAccount() { BankId = "12345", BranchId = "67890", AccountId = "987456321", AccountType = AccountEnum.MONEYMRKT };
            var xml = $"<BANKACCTFROM><BANKID>{expected.BankId}</BANKID><BRANCHID>{expected.BranchId}</BRANCHID><ACCTID>{expected.AccountId}</ACCTID><ACCTTYPE>{expected.AccountType}</ACCTTYPE></BANKACCTFROM>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Full()
        {
            var expected = new BankAccount() { BankId = "12345", BranchId = "67890", AccountId = "987456321", AccountType = AccountEnum.MONEYMRKT, AccountKey = "321456987" };
            var xml = $"<BANKACCTFROM><BANKID>{expected.BankId}</BANKID><BRANCHID>{expected.BranchId}</BRANCHID><ACCTID>{expected.AccountId}</ACCTID><ACCTTYPE>{expected.AccountType}</ACCTTYPE><ACCTKEY>{expected.AccountKey}</ACCTKEY></BANKACCTFROM>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Empty()
        {
            var expected = new BankAccount();
            var xml = $"<BANKACCTFROM></BANKACCTFROM>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<BANKACCTFROM><UNKNOWN>My unknown value</UNKNOWN></BANKACCTFROM>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, BankAccount? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new BANKACCTFROM().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}