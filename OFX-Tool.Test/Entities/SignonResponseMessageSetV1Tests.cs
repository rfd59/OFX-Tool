using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities.Signon;
using System;

namespace RFD.OFXTool.Library.Entities.Tests
{
    [TestClass()]
    public class SignonResponseMessageSetV1Tests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new SignonResponseMessageSetV1();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new SignonResponseMessageSetV1());
            Assert.AreNotEqual(entity, new SignonResponseMessageSetV1() { SignonResponse = new SignonResponse() });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new SignonResponseMessageSetV1();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}