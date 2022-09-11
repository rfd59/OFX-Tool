using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using RFD.OFXTool.Library.Entities.Signon;
using System.Text;

namespace RFD.OFXTool.Library.Core.Build
{
    internal class BuildSTMTTRNRS : BuildAbstract<StatementTransactionResponse>
    {
        public BuildSTMTTRNRS(StatementTransactionResponse doc, int level = 0) : base(doc, level)
        {
        }

        protected override void BuildElement(StatementTransactionResponse doc)
        {
            if (doc.Status != null)
                Element.Append(new BuildSTATUS(doc.Status, Level + 1).Element);
            if (doc.StatementResponse != null)
                Element.Append(new BuildSTMTRS(doc.StatementResponse, Level + 1).Element);
            if (doc.TransactionUniqueId != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransactionResponse>(nameof(StatementTransactionResponse.TransactionUniqueId)).Name, doc.TransactionUniqueId.ToString(), Level));
            if (doc.ClientCookie != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementTransactionResponse>(nameof(StatementTransactionResponse.ClientCookie)).Name, doc.ClientCookie, Level));
        }
    }
}