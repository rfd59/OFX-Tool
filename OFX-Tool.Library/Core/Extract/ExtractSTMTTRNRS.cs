using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractSTMTTRNRS
    {
        internal StatementTransactionResponse Element { get; }

        internal ExtractSTMTTRNRS(XmlTextReader xmlReader)
        {
            Element = new StatementTransactionResponse();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals(Entity.GetElementClass<StatementTransactionResponse>().Name))
                {
                    break;
                }

                // STATUS element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElementClass<Status>().Name))
                {
                    Element.Status = new ExtractSTATUS(xmlReader).Element;
                }

                // STMTRS element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElementClass<StatementResponse>().Name))
                {
                    Element.StatementResponse = new ExtractSTMTRS(xmlReader).Element;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    if (myField == Entity.GetElementProperty<StatementTransactionResponse>(nameof(StatementTransactionResponse.TransactionUniqueId)).Name)
                        Element.TransactionUniqueId = xmlReader.Value;
                    else if (myField == Entity.GetElementProperty<StatementTransactionResponse>(nameof(StatementTransactionResponse.ClientCookie)).Name)
                        Element.ClientCookie = xmlReader.Value;
                    else
                        throw new InvalidOperationException($"Unexpected value! [{myField}]");
                }
            }
        }
    }
}
