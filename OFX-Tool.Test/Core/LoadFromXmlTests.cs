using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Core;
using RFD.OFXTool.Library.Ofx;
using RFD.OFXTool.Library.Ofx.Bank;
using RFD.OFXTool.Library.Ofx.Signon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library.Core.Tests
{
    [TestClass()]
    public class LoadFromXmlTests
    {
        [TestMethod()]
        [ExpectedException(typeof(OFXToolException))]
        public void XmlNotFound()
        {
            new LoadFromXml("notExist.xml");
        }

        [TestMethod]
        public void LoadFromXml()
        {
            var status = new Status() { Code = "0", Severity = SeverityEnum.INFO };
            var sonrs = new SignonResponse() { Language = LanguageEnum.FRA, ServerDate = "20220802000000", Status = status };
            var bankacctfrom = new BankAccount() { BankId= "12345", BranchId= "6789", AccountId= "00112233445", AccountType= AccountEnum.CHECKING };
            var stmttrn = new List<StatementTransaction>();
            stmttrn.Add (new StatementTransaction() { TransactionType = TransactionEnum.CREDIT, PostedDate = "20220602", UserDate = "20220602", TransactionAmount = "450.00", FinancialInstitutionTransactionId = "AZ1ERT23YU", Memo = "VIR SURNAME NAME" });
            var banktranslist = new BankTransactionList() { StartDate= "20220602000000", EndDate= "20220728000000", StatementTransactions=stmttrn };
            var ledgerbal = new LedgerBalance() { BalanceAmount= "12345.67", DateAsOf= "20220728000000" };
            var availbal = new AvailableBalance() { BalanceAmount = "0.00", DateAsOf = "20220728000000" };
            var stmtrs = new StatementResponse() { Currency = CurrencyEnum.EUR, BankAccountFrom = bankacctfrom, BankTransactionList = banktranslist, LedgerBalance=ledgerbal, AvailableBalance=availbal };
            var stmttrns = new List<StatementTransactionResponse>();
            stmttrns.Add(new StatementTransactionResponse() { TransactionUniqueId= "20220802000000", Status=status, StatementResponse=stmtrs });

            var xmlFile = "TestFiles/LoadFromXmlTest1.xml";
            var load = new LoadFromXml(xmlFile);

            Assert.AreEqual(xmlFile, load.XmlFile);
            Assert.IsNotNull(load.OfxDocument);
            Assert.AreEqual(new SignonResponseMessageSetV1() { SignonResponse = sonrs }, load.OfxDocument.SignonResponseMessageSetV1);
            Assert.AreEqual(new BankResponseMessageSetV1() { StatementTransactionResponses= stmttrns }, load.OfxDocument.BankResponseMessageSetV1);
        }
    }
}