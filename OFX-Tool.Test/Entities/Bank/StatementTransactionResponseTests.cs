using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Bank.Tests
{
    [TestClass()]
    public class StatementTransactionResponseTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new StatementTransactionResponse();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new StatementTransactionResponse());
            Assert.AreNotEqual(entity, new StatementTransactionResponse() { TransactionUniqueId = "12345" });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new StatementTransactionResponse();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}