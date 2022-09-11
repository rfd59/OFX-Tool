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
    public class STMTTRNRSTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var doc = new StatementTransactionResponse() { TransactionUniqueId="789654123" };
            var expected = $"<STMTTRNRS><TRNUID>{doc.TransactionUniqueId}</STMTTRNRS>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Full()
        {
            var doc = new StatementTransactionResponse() { TransactionUniqueId = "789654123", ClientCookie="azertyuiop", StatementResponse=new StatementResponse(), Status= new Status() };
            var expected = $"<STMTTRNRS><TRNUID>{doc.TransactionUniqueId}<CLTCOOKIE>{doc.ClientCookie}<STATUS></STATUS><STMTRS></STMTRS></STMTTRNRS>";

            BuildAssert(doc, expected);
        }

        [TestMethod()]
        public void BuildTest_Empty()
        {
            var doc = new StatementTransactionResponse();
            var expected = $"<STMTTRNRS></STMTTRNRS>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(StatementTransactionResponse doc, string expected)
        {
            var build = new STMTTRNRS().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var expected = new StatementTransactionResponse() { TransactionUniqueId = "789654123" };
            var xml = $"<STMTTRNRS><TRNUID>{expected.TransactionUniqueId}</TRNUID></STMTTRNRS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Full()
        {
            var expected = new StatementTransactionResponse() { TransactionUniqueId = "789654123", ClientCookie = "azertyuiop", StatementResponse = new StatementResponse(), Status = new Status() };
            var xml = $"<STMTTRNRS><TRNUID>{expected.TransactionUniqueId}</TRNUID><CLTCOOKIE>{expected.ClientCookie}</CLTCOOKIE><STATUS></STATUS><STMTRS></STMTRS></STMTTRNRS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        public void LoadTest_Empty()
        {
            var expected = new StatementTransactionResponse();
            var xml = $"<STMTTRNRS></STMTTRNRS>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<STMTTRNRS><UNKNOWN>My unknown value</UNKNOWN></STMTTRNRS>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, StatementTransactionResponse? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new STMTTRNRS().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}