using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace RFD.OFXTool.Library.Entities.Tests
{
    [TestClass()]
    public class BankResponseMessageSetV1Tests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new BankResponseMessageSetV1();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new BankResponseMessageSetV1());
            Assert.AreNotEqual(entity, new BankResponseMessageSetV1() { StatementTransactionResponses = new List<Bank.StatementTransactionResponse>() });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new BankResponseMessageSetV1();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}