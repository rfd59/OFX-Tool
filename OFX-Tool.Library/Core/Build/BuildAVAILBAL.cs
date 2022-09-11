using RFD.OFXTool.Library.Entities;

namespace RFD.OFXTool.Library.Core.Build
{
    internal class BuildAVAILBAL : BuildAbstract<AvailableBalance>
    {
        public BuildAVAILBAL(AvailableBalance doc, int level = 0) : base(doc, level)
        {
        }

        protected override void BuildElement(AvailableBalance doc)
        {
            if (doc.BalanceAmount != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<LedgerBalance>(nameof(LedgerBalance.BalanceAmount)).Name, doc.BalanceAmount, Level));
            if (doc.DateAsOf != null)
                Element.AppendLine(BuildToFile.WriteProperty(Entity.GetElementProperty<LedgerBalance>(nameof(LedgerBalance.DateAsOf)).Name, doc.DateAsOf, Level));
        }
    }
}