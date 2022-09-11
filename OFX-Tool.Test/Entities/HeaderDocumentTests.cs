using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Entities.Tests
{
    [TestClass()]
    public class HeaderDocumentTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new HeaderDocument();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new HeaderDocument());
            Assert.AreNotEqual(entity, new HeaderDocument() { Version = "103" });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new HeaderDocument();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}