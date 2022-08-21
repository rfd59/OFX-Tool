using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RFD.OFXTool.Library.Core.Tests
{
    [TestClass()]
    public class OFXToolExceptionTests
    {
        [TestMethod()]
        [ExpectedException(typeof(OFXToolException))]
        public void OFXToolExceptionTest()
        {
            throw new OFXToolException();
        }

        [TestMethod()]
        [ExpectedException(typeof(OFXToolException))]
        public void OFXToolExceptionMessageTest()
        {
            var message = "A custom exception message!";

            try
            {
                throw new OFXToolException(message);
            }
            catch (OFXToolException ote)
            {
                Assert.AreEqual(message, ote.Message);
                throw;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(OFXToolException))]
        public void OFXToolExceptionInnerExceptionTest()
        {
            var message = "A custom exception message with inner exception!";

            try
            {
                throw new OFXToolException(message, new NullReferenceException());
            }
            catch (OFXToolException ote)
            {
                Assert.AreEqual(message, ote.Message);
                Assert.IsNotNull(ote.InnerException);
                Assert.AreEqual(typeof(NullReferenceException), ote.InnerException.GetType());

                throw;
            }

            throw new OFXToolException("a custom message", new Exception());
        }
    }
}