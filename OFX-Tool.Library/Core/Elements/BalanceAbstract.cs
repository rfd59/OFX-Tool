using RFD.OFXTool.Library.Entities;
using System.Xml;

namespace RFD.OFXTool.Library.Core.Elements
{
    internal abstract class BalanceAbstract<T> : ElementAbstract<T> where T : AbstractBalance
    {
        protected override void BuildElement(T doc)
        {
            if (doc.BalanceAmount != null)
                _build.AppendLine(WriteProperty<LedgerBalance>(nameof(LedgerBalance.BalanceAmount), doc.BalanceAmount, _level));
            if (doc.DateAsOf != null)
                _build.AppendLine(WriteProperty<LedgerBalance>(nameof(LedgerBalance.DateAsOf), doc.DateAsOf, _level));
        }

        protected override void LoadElement(XmlTextReader xmlReader)
        {
            if (xmlReader.NodeType == XmlNodeType.Text)
            {
                if (_field == Entity.GetElement<LedgerBalance>(nameof(LedgerBalance.BalanceAmount)))
                    _load.BalanceAmount = xmlReader.Value;
                else if (_field == Entity.GetElement<LedgerBalance>(nameof(LedgerBalance.DateAsOf)))
                    _load.DateAsOf = xmlReader.Value;
                else
                    throw new InvalidOperationException($"Unexpected value! [{_field}]");
            }
        }
    }
}