using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal class STMTTRNRS : ElementAbstract<StatementTransactionResponse>
    {
        protected override void BuildElement(StatementTransactionResponse doc)
        {
            if (doc.TransactionUniqueId != null)
                _build.AppendLine(WriteProperty<StatementTransactionResponse>(nameof(StatementTransactionResponse.TransactionUniqueId), doc.TransactionUniqueId.ToString(), _level));
            if (doc.Status != null)
                _build.Append(new STATUS().Build(doc.Status, _level + 1));
            if (doc.ClientCookie != null)
                _build.AppendLine(WriteProperty<StatementTransactionResponse>(nameof(StatementTransactionResponse.ClientCookie), doc.ClientCookie, _level));
            if (doc.StatementResponse != null)
                _build.Append(new STMTRS().Build(doc.StatementResponse, _level + 1));
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            // STATUS element object
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<Status>()))
            {
                _load.Status = new STATUS().Load(xmlReader);
            }

            // STMTRS element object
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<StatementResponse>()))
            {
                _load.StatementResponse = new STMTRS().Load(xmlReader);
            }

            if (xmlReader.NodeType == XmlNodeType.Text)
            {
                if (_field == Entity.GetElement<StatementTransactionResponse>(nameof(StatementTransactionResponse.TransactionUniqueId)))
                    _load.TransactionUniqueId = xmlReader.Value;
                else if (_field == Entity.GetElement<StatementTransactionResponse>(nameof(StatementTransactionResponse.ClientCookie)))
                    _load.ClientCookie = xmlReader.Value;
                else
                    throw new InvalidOperationException($"Unexpected value! [{_field}]");
            }
        }
    }
}