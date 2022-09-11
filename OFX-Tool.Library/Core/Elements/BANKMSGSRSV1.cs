using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal class BANKMSGSRSV1 : ElementAbstract<BankResponseMessageSetV1>
    {
        protected override void BuildElement(BankResponseMessageSetV1 doc)
        {
            if (doc.StatementTransactionResponses != null)
            {
                foreach (var str in doc.StatementTransactionResponses)
                    _build.Append(new STMTTRNRS().Build(str, _level + 1));
            }
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            // SONRS element object
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name.Equals(Entity.GetElement<StatementTransactionResponse>()))
            {
                if (_load.StatementTransactionResponses == null)
                    _load.StatementTransactionResponses = new List<StatementTransactionResponse>();

                _load.StatementTransactionResponses.Add(new STMTTRNRS().Load(xmlReader));
            }
        }
    }
}