using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Tests
{
    [TestClass()]
    public class LedgerBalanceTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new LedgerBalance();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new LedgerBalance());
            Assert.AreNotEqual(entity, new LedgerBalance() { BalanceAmount = "123" });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new LedgerBalance();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}