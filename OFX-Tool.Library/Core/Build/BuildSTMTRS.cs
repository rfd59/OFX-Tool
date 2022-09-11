using RFD.OFXTool.Library.Entities;
using RFD.OFXTool.Library.Entities.Bank;
using RFD.OFXTool.Library.Entities.Signon;
using System.Text;

namespace RFD.OFXTool.Library.Core.Build
{
    internal class BuildSTMTRS : BuildAbstract<StatementResponse>
    {
        public BuildSTMTRS(StatementResponse doc, int level = 0) : base(doc, level)
        {
        }

        protected override void BuildElement(StatementResponse doc)
        {
            if (doc.BankAccountFrom != null)
                Element.Append(new BuildBANKACCTFROM(doc.BankAccountFrom, Level + 1).Element);
            if (doc.BankTransactionList != null)
                Element.Append(new BuildBANKTRANLIST(doc.BankTransactionList, Level + 1).Element);
            if (doc.LedgerBalance != null)
                Element.Append(new BuildLEDGERBAL(doc.LedgerBalance, Level + 1).Element);
            if (doc.AvailableBalance != null)
                Element.Append(new BuildAVAILBAL(doc.AvailableBalance, Level + 1).Element); 
            if (doc.Currency != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<StatementResponse>(nameof(StatementResponse.Currency)).Name, doc.Currency.ToString(), Level));
        }
    }
}