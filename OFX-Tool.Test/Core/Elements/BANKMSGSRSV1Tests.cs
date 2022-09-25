using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements.Tests
{
    [TestClass()]
    public class BANKMSGSRSV1Tests
    {
        [TestMethod()]
        public void BuildTest()
        {
            var str = new List<StatementTransactionResponse>();
            str.Add(new StatementTransactionResponse());

            var doc = new BankResponseMessageSetV1() { StatementTransactionResponses = str };
            var expected = $"<BANKMSGSRSV1><STMTTRNRS></STMTTRNRS></BANKMSGSRSV1>";

            BuildAssert(doc, expected);
        }

        private void BuildAssert(BankResponseMessageSetV1 doc, string expected)
        {
            var build = new BANKMSGSRSV1().Build(doc);

            Assert.IsNotNull(build);
            Assert.AreEqual(expected, build.ToString().Replace(Environment.NewLine, "").Replace("\t", ""));
            Assert.AreEqual(expected.Split('<').Length, build.ToString().Split(Environment.NewLine).Length);
        }


        [TestMethod()]
        public void LoadTest()
        {
            var str = new List<StatementTransactionResponse>();
            str.Add(new StatementTransactionResponse());

            var expected = new BankResponseMessageSetV1() { StatementTransactionResponses = str };
            var xml = $"<BANKMSGSRSV1><STMTTRNRS></STMTTRNRS></BANKMSGSRSV1>";

            LoadAssert(xml, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadTest_Unknown()
        {
            var xml = $"<BANKMSGSRSV1><UNKNOWN>My unknown value</UNKNOWN></BANKMSGSRSV1>";

            LoadAssert(xml, null);
        }

        private void LoadAssert(string xmlInput, BankResponseMessageSetV1? expected)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlInput));

            var load = new BANKMSGSRSV1().Load(reader);

            Assert.IsNotNull(load);
            Assert.AreEqual(expected, load);
        }
    }
}