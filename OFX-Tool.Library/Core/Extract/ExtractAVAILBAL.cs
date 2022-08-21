using RFD.OFXTool.Library.Ofx;
using RFD.OFXTool.Library.Ofx.Signon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractAVAILBAL
    {
        internal AvailableBalance Element { get; }

        internal ExtractAVAILBAL(XmlTextReader xmlReader)
        {
            Element = new AvailableBalance();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("AVAILBAL"))
                {
                    break;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    switch(myField)
                    {
                        case "BALAMT":
                            Element.BalanceAmount = xmlReader.Value;
                            break;
                        case "DTASOF":
                            Element.DateAsOf = xmlReader.Value;
                            break;
                    }
                }
            }
        }
    }
}
