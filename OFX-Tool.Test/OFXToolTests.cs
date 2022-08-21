using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library.Tests
{
    [TestClass()]
    public class OFXToolTests
    {
        [TestMethod()]
        public void GetExtractTest()
        {
            var document = OFXTool.GetExtract("TestFiles/ExportToXmlTest1.ofx");
            Assert.IsNotNull(document);
            Assert.AreEqual("20220802000000", document.SignonResponseMessageSetV1.SignonResponse.ServerDate);
            Assert.AreEqual("450.00", document.BankResponseMessageSetV1.StatementTransactionResponses[0].StatementResponse.BankTransactionList.StatementTransactions[0].TransactionAmount);
        }

    }
}