using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library.Entities.Tests
{
    [TestClass()]
    public class ResponseDocumentTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var entity = new ResponseDocument();
            Assert.IsFalse(entity.Equals(null));
            Assert.IsFalse(entity.Equals(new Object()));
            Assert.AreEqual(entity, new ResponseDocument());
            Assert.AreNotEqual(entity, new ResponseDocument() { BankResponseMessageSetV1 = new BankResponseMessageSetV1() });
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var entity = new ResponseDocument();
            Assert.IsNotNull(entity.GetHashCode());
        }
    }
}