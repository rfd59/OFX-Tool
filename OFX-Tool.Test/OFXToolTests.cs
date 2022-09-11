using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Core;
using RFD.OFXTool.Library.Entities;
using System.IO;

namespace RFD.OFXTool.Library.Tests
{
    [TestClass()]
    public class OfxToolTests
    {
        [TestMethod()]
        public void LoadTest()
        {
            var document = OfxTool.Get("TestFiles/ExportToXmlTest1.ofx").Response;
            Assert.IsNotNull(document);
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
            Assert.AreEqual("20220802000000", document.SignonResponseMessageSetV1.SignonResponse.ServerDate);
            Assert.AreEqual("450.00", document.BankResponseMessageSetV1.StatementTransactionResponses[0].StatementResponse.BankTransactionList.StatementTransactions[0].TransactionAmount);
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
        }

        [TestMethod()]
        [ExpectedException(typeof(OFXToolException))]
        public void LoadTest_OfxNotExist()
        {
            var ofxTool = new OfxTool();
            ofxTool.Load("UnknowOfxFile");
        }

        [TestMethod()]
        public void BuildTest()
        {
            var file = "./myFile.ofx";

            OfxTool.Set(new Ofx(), file);

            Assert.IsTrue(File.Exists(file));
        }

        [TestMethod()]
        [ExpectedException(typeof(OFXToolException))]
        public void BuildTest_OfxNull()
        {
            var ofxTool = new OfxTool();
            ofxTool.Build(null, "ofxTargetFile");
        }
    }
}