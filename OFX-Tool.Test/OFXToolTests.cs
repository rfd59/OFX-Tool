using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RFD.OFXTool.Library.Tests
{
    [TestClass()]
    public class OFXToolTests
    {
        [TestMethod()]
        public void GetExtractTest()
        {
            var document = OfxTool.Get("TestFiles/ExportToXmlTest1.ofx").Response;
            Assert.IsNotNull(document);
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
            Assert.AreEqual("20220802000000", document.SignonResponseMessageSetV1.SignonResponse.ServerDate);
            Assert.AreEqual("450.00", document.BankResponseMessageSetV1.StatementTransactionResponses[0].StatementResponse.BankTransactionList.StatementTransactions[0].TransactionAmount);
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
        }

    }
}