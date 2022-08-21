using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Bank.Tests
{
    [TestClass()]
    public class StatementResponseTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new StatementResponse();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new StatementResponse());
            Assert.AreNotEqual(entity, new StatementResponse() { Currency = CurrencyEnum.AFN });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new StatementResponse();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}