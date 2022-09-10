using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Extract
{
    internal class ExtractSTMTRS
    {
        internal StatementResponse Element { get; }

        internal ExtractSTMTRS(XmlTextReader xmlReader)
        {
            Element = new StatementResponse();
            var myField = "";

            while (xmlReader.Read())
            {
                // End of this element object
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals(Entity.GetElementClass<StatementResponse>().Name))
                {
                    break;
                }

                // BANKACCTFROM element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElementClass<BankAccount>().Name))
                {
                    Element.BankAccountFrom = new ExtractBANKACCTFROM(xmlReader).Element;
                }

                // BANKTRANLIST element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElementClass<BankTransactionList>().Name))
                {
                    Element.BankTransactionList = new ExtractBANKTRANLIST(xmlReader).Element;
                }

                // LEDGERBAL element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElementClass<LedgerBalance>().Name))
                {
                    Element.LedgerBalance = new ExtractLEDGERBAL(xmlReader).Element;
                }

                // AVAILBAL element object
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElementClass<AvailableBalance>().Name))
                {
                    Element.AvailableBalance = new ExtractAVAILBAL(xmlReader).Element;
                }

                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    myField = xmlReader.Name;
                }

                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    if (myField == Entity.GetElementProperty<StatementResponse>(nameof(StatementResponse.Currency)).Name)
                        Element.Currency = (CurrencyEnum)Enum.Parse(typeof(CurrencyEnum), xmlReader.Value);
                    else
                        throw new InvalidOperationException($"Unexpected value! [{myField}]");
                }
            }
        }
    }
}
