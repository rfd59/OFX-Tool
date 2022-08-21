using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Bank.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new BankAccount();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new BankAccount());
            Assert.AreNotEqual(entity, new BankAccount() { AccountId = "123" });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new BankAccount();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}