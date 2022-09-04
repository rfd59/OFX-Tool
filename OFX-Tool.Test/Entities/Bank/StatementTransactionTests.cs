using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Bank.Tests
{
    [TestClass()]
    public class StatementTransactionTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new StatementTransaction();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new StatementTransaction());
            Assert.AreNotEqual(entity, new StatementTransaction() { Name = "MyName" });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new StatementTransaction();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}