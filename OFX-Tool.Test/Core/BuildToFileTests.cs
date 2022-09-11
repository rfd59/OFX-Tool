using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Core;
using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using RFD.OFXTool.Library.Entities.Signon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library.Core.Tests
{
    [TestClass()]
    public class BuildToFileTests
    {
        [TestMethod()]
        public void BuildToFileTest()
        {
            var doc = new ResponseDocument();

            var status = new Status() { Code = "0", Severity = SeverityEnum.INFO };
            var sonrs = new SignonResponse() { Language = LanguageEnum.FRA, ServerDate = "20220802000000", Status = status };
            doc.SignonResponseMessageSetV1 = new SignonResponseMessageSetV1() { SignonResponse = sonrs };

            var bankacctfrom = new BankAccount() { BankId = "12345", BranchId = "6789", AccountId = "00112233445", AccountType = AccountEnum.CHECKING };
            var stmttrn = new List<StatementTransaction>();
            stmttrn.Add(new StatementTransaction() { TransactionType = TransactionEnum.CREDIT, PostedDate = "20220602", UserDate = "20220602", TransactionAmount = "450.00", FinancialInstitutionTransactionId = "AZ1ERT23YU", Memo = "VIR SURNAME NAME" });
            stmttrn.Add(new StatementTransaction() { TransactionType = TransactionEnum.DEBIT, PostedDate = "20220702", UserDate = "20220702", TransactionAmount = "50.00", FinancialInstitutionTransactionId = "NBVCXW98", Memo = "FOOD", CheckNumber = "123456" });
            var banktranslist = new BankTransactionList() { StartDate = "20220602000000", EndDate = "20220728000000", StatementTransactions = stmttrn };
            var ledgerbal = new LedgerBalance() { BalanceAmount = "12345.67", DateAsOf = "20220728000000" };
            var availbal = new AvailableBalance() { BalanceAmount = "0.00", DateAsOf = "20220728000000" };
            var stmtrs = new StatementResponse() { Currency = CurrencyEnum.EUR, BankAccountFrom = bankacctfrom, BankTransactionList = banktranslist, LedgerBalance = ledgerbal, AvailableBalance = availbal };
            var stmttrns = new List<StatementTransactionResponse>();
            stmttrns.Add(new StatementTransactionResponse() { TransactionUniqueId = "20220802000000", Status = status, StatementResponse = stmtrs });
            doc.BankResponseMessageSetV1 = new BankResponseMessageSetV1() { StatementTransactionResponses = stmttrns};

            new BuildToFile(doc, "./build.ofx");
        }
    }
}