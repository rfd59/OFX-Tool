using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Signon.Tests
{
    [TestClass()]
    public class SignonResponseTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new SignonResponse();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new SignonResponse());
            Assert.AreNotEqual(entity, new SignonResponse() { ServerDate = "12345" });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new SignonResponse();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}