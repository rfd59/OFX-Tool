using RFD.OFXTool.Library.Core.Extract;
using RFD.OFXTool.Library.Ofx;
using RFD.OFXTool.Library.Ofx.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RFD.OFXTool.Library.Core
{
    public class LoadFromXml
    {
        public string XmlFile { get; }
        public ResponseDocument OfxDocument { get; }

        public LoadFromXml(string xmlFile)
        {
            XmlFile = xmlFile;
            OfxDocument = new ResponseDocument();

            //
            Extract();

        }

        private void Extract()
        {
            // 
            var xmlReader = new XmlTextReader(XmlFile);
            try
            {
                while (xmlReader.Read())
                {
                    //
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("SIGNONMSGSRSV1"))
                    {
                        OfxDocument.SignonResponseMessageSetV1 = new ExtractSIGNONMSGSRSV1(xmlReader).Element;
                    }

                    //
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals("BANKMSGSRSV1"))
                    {
                        OfxDocument.BankResponseMessageSetV1 = new ExtractBANKMSGSRSV1(xmlReader).Element;
                    }
                }
            }
            catch (Exception e)
            {
                throw new OFXToolException($"Invalid OFX file! [{e.Message}]", e);
            }
            finally
            {
                xmlReader.Close();
            }
        }
    }
}