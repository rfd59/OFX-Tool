using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFD.OFXTool.Library.Core;
using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Signon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library.Core.Tests
{
    [TestClass()]
    public class BuildToFileTests
    {
        [TestMethod()]
        public void BuildToFileTest()
        {
            var status = new Status() { Code = "0", Severity = SeverityEnum.INFO };
            var sonrs = new SignonResponse() { Language = LanguageEnum.FRA, ServerDate = "20220802000000", Status = status };

            var doc = new ResponseDocument();
            doc.SignonResponseMessageSetV1 = new SignonResponseMessageSetV1() { SignonResponse = sonrs};

            new BuildToFile(doc, "./build.ofx");
        }
    }
}