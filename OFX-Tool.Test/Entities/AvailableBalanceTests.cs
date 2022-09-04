using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Tests
{
    [TestClass()]
    public class AvailableBalanceTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new AvailableBalance();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new AvailableBalance());
            Assert.AreNotEqual(entity, new AvailableBalance() { BalanceAmount = "123" });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new AvailableBalance();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}