using RFD.OFXTool.Library.Entities.Bank;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal class BANKTRANLIST : ElementAbstract<BankTransactionList>
    {
        protected override void BuildElement(BankTransactionList doc)
        {
            if (doc.StartDate != null)
                _build.AppendLine(WriteProperty<BankTransactionList>(nameof(BankTransactionList.StartDate), doc.StartDate, _level));
            if (doc.EndDate != null)
                _build.AppendLine(WriteProperty<BankTransactionList>(nameof(BankTransactionList.EndDate), doc.EndDate, _level));
            if (doc.StatementTransactions != null)
            {
                foreach (var st in doc.StatementTransactions)
                    _build.Append(new STMTTRN().Build(st, _level + 1));
            }
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            // STMTTRN element object
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<StatementTransaction>()))
            {
                if (_load.StatementTransactions == null)
                {
                    _load.StatementTransactions = new List<StatementTransaction>();
                }

                _load.StatementTransactions.Add(new STMTTRN().Load(xmlReader));
            }

            if (xmlReader.NodeType == XmlNodeType.Text)
            {
                if (_field == Entity.GetElement<BankTransactionList>(nameof(BankTransactionList.StartDate)))
                    _load.StartDate = xmlReader.Value;
                else if (_field == Entity.GetElement<BankTransactionList>(nameof(BankTransactionList.EndDate)))
                    _load.EndDate = xmlReader.Value;
                else
                    throw new InvalidOperationException($"Unexpected value! [{_field}]");
            }
        }
    }
}