using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements.Tests
{

    [TestClass()]
    public class ElementAbstractTests
    {
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void LoadTest_NullReference()
        {
            new TestElement().Load(null);
        }

    }

    internal class TestElement : ElementAbstract<Object>
    {
        protected override void BuildElement(object doc)
        {
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
        }
    }
}
