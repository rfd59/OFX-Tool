using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Bank.Tests
{
    [TestClass()]
    public class BankTransactionListTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new BankTransactionList();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new BankTransactionList());
            Assert.AreNotEqual(entity, new BankTransactionList() { StartDate = "123" });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new BankTransactionList();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}