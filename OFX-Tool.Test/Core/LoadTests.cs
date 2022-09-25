using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using RFD.OFXTool.Library.Entities.Signon;
using RFD.OFXTool.Library.Enums;
using System.Collections.Generic;

namespace RFD.OFXTool.Library.Core.Tests
{
    [TestClass()]
    public class LoadTests
    {
        [TestMethod()]
        [ExpectedException(typeof(OFXToolException))]
        public void LoadTest_OfxNotFound()
        {
            new Load("notExist.ofx");
        }

        [TestMethod]
        public void LoadTest()
        {
            var ofx = new Ofx();

            ofx.Header = new HeaderDocument() { OfxHeader = "000", Data = "AZERTY", Version = "111", Security = "SECU", Encoding = "ENCO", Charset = "1234", Compression = "COMP", OldFileUid = "OLD", NewFileUid = "NEW" };

            var status = new Status() { Code = "0", Severity = SeverityEnum.INFO };
            var sonrs = new SignonResponse() { Language = LanguageEnum.FRA, ServerDate = "20220802000000", Status = status };
            var bankacctfrom = new BankAccount() { BankId = "12345", BranchId = "6789", AccountId = "00112233445", AccountType = AccountEnum.CHECKING };
            var stmttrn = new List<StatementTransaction>();
            stmttrn.Add(new StatementTransaction() { TransactionType = TransactionEnum.CREDIT, PostedDate = "20220602", UserDate = "20220603", TransactionAmount = "450.00", FinancialInstitutionTransactionId = "AZ1ERT23YU", Memo = "VIR SURNAME NAME" });
            stmttrn.Add(new StatementTransaction() { TransactionType = TransactionEnum.DEBIT, PostedDate = "20220702", UserDate = "20220703", TransactionAmount = "50.00", FinancialInstitutionTransactionId = "NBVCXW98", Memo = "FOOD", CheckNumber = "123456" });
            var banktranslist = new BankTransactionList() { StartDate = "20220602000000", EndDate = "20220728000000", StatementTransactions = stmttrn };
            var ledgerbal = new LedgerBalance() { BalanceAmount = "12345.67", DateAsOf = "20220728000000" };
            var availbal = new AvailableBalance() { BalanceAmount = "0.00", DateAsOf = "20220729000000" };
            var stmtrs = new StatementResponse() { Currency = CurrencyEnum.EUR, BankAccountFrom = bankacctfrom, BankTransactionList = banktranslist, LedgerBalance = ledgerbal, AvailableBalance = availbal };
            var stmttrns = new List<StatementTransactionResponse>();
            stmttrns.Add(new StatementTransactionResponse() { TransactionUniqueId = "20220802000000", Status = status, StatementResponse = stmtrs });
            var signonmsgsrsV1 = new SignonResponseMessageSetV1() { SignonResponse = sonrs };
            var bankmsgsrsv1 = new BankResponseMessageSetV1() { StatementTransactionResponses = stmttrns };
            ofx.Response = new ResponseDocument() { SignonResponseMessageSetV1 = signonmsgsrsV1, BankResponseMessageSetV1 = bankmsgsrsv1 };

            var ofxFile = "TestFiles/LoadTest1.ofx";
            var load = new Load(ofxFile);

            Assert.AreEqual(ofxFile, load.OfxFile);
            Assert.IsNotNull(load.Ofx);

            Assert.AreEqual(ofx.Header, load.Ofx.Header);
            Assert.AreEqual(ofx.Response, load.Ofx.Response);
            Assert.AreEqual(ofx, load.Ofx);
        }

        [TestMethod]
        [ExpectedException(typeof(OFXToolException))]
        public void LoadTest_UnknownHeader()
        {
            var ofxFile = "TestFiles/LoadTest_UnknownHeader.ofx";
            new Load(ofxFile);
        }
    }
}