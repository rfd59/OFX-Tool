﻿using RFD.OFXTool.Library.Attributes;

namespace RFD.OFXTool.Library.Entities
{
    [Element("LEDGERBAL", ElementTypeEnum.CLASS)]
    public class LedgerBalance
    {
        //
        // Résumé :
        //     Gets or sets the ledger balance amount.
        [Element("BALAMT", ElementTypeEnum.PROPERTY)]
        public string? BalanceAmount { get; set; }
        //
        // Résumé :
        //     Gets or sets the balance date.
        [Element("DTASOF", ElementTypeEnum.PROPERTY)]
        public string? DateAsOf { get; set; }

        // Determines whether the specified object is equal to the current object.
        public override bool Equals(object? obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                LedgerBalance e = (LedgerBalance)obj;
                return Entity.PropertyEquality(e.BalanceAmount, BalanceAmount) &&
                    Entity.PropertyEquality(e.DateAsOf, DateAsOf);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { BalanceAmount, DateAsOf }.GetHashCode();
    }
}
