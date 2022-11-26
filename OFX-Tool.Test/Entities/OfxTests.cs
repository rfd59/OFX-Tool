using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Tests
{
    [TestClass()]
    public class OfxTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new Ofx();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new Ofx());
            Assert.AreNotEqual(entity, new Ofx() { Response = new ResponseDocument() { SignonResponseMessageSetV1 = new SignonResponseMessageSetV1() } });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new Ofx();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}