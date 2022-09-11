using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal class STMTRS : ElementAbstract<StatementResponse>
    {
        protected override void BuildElement(StatementResponse doc)
        {
            if (doc.Currency != null)
                _build.AppendLine(WriteProperty<StatementResponse>(nameof(StatementResponse.Currency), doc.Currency, _level));
            if (doc.BankAccountFrom != null)
                _build.Append(new BANKACCTFROM().Build(doc.BankAccountFrom, _level + 1));
            if (doc.BankTransactionList != null)
                _build.Append(new BANKTRANLIST().Build(doc.BankTransactionList, _level + 1));
            if (doc.LedgerBalance != null)
                _build.Append(new LEDGERBAL().Build(doc.LedgerBalance, _level + 1));
            if (doc.AvailableBalance != null)
                _build.Append(new AVAILBAL().Build(doc.AvailableBalance, _level + 1));
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            // BANKACCTFROM element object
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<BankAccount>()))
            {
                _load.BankAccountFrom = new BANKACCTFROM().Load(xmlReader);
            }

            // BANKTRANLIST element object
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<BankTransactionList>()))
            {
                _load.BankTransactionList = new BANKTRANLIST().Load(xmlReader);
            }

            // LEDGERBAL element object
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<LedgerBalance>()))
            {
                _load.LedgerBalance = new LEDGERBAL().Load(xmlReader);
            }

            // AVAILBAL element object
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<AvailableBalance>()))
            {
                _load.AvailableBalance = new AVAILBAL().Load(xmlReader);
            }

            if (xmlReader.NodeType == XmlNodeType.Text)
            {
                if (_field == Entity.GetElement<StatementResponse>(nameof(StatementResponse.Currency)))
                    _load.Currency = (CurrencyEnum)Enum.Parse(typeof(CurrencyEnum), xmlReader.Value);
                else
                    throw new InvalidOperationException($"Unexpected value! [{_field}]");
            }
        }
    }
}