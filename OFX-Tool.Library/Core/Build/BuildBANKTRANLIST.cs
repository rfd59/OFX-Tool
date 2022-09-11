using RFD.OFXTool.Library.Entities.Bank;

namespace RFD.OFXTool.Library.Core.Build
{
    internal class BuildBANKTRANLIST : BuildAbstract<BankTransactionList>
    {
        public BuildBANKTRANLIST(BankTransactionList doc, int level = 0) : base(doc, level)
        {
        }

        protected override void BuildElement(BankTransactionList doc)
        {
            if (doc.StartDate != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<BankTransactionList>(nameof(BankTransactionList.StartDate)).Name, doc.StartDate, Level));
            if (doc.EndDate != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<BankTransactionList>(nameof(BankTransactionList.EndDate)).Name, doc.EndDate, Level));
            if (doc.StatementTransactions != null)
            {
                foreach (var st in doc.StatementTransactions)
                    Element.Append(new BuildSTMTTRN(st, Level + 1).Element);
            }
                   
            
    }
    }
}