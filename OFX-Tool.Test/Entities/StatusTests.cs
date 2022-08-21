using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Tests
{
    [TestClass()]
    public class StatusTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new Status();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new Status());
            Assert.AreNotEqual(entity, new Status() { Code = "123" });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new Status();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}