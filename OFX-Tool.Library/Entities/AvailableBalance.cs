﻿namespace RFD.OFXTool.Library.Entities
{
    public class AvailableBalance
    {
        //
        // Résumé :
        //     Gets or sets the available balance amount.
        public string? BalanceAmount { get; set; }
        //
        // Résumé :
        //     Gets or sets the balance date.
        public string? DateAsOf { get; set; }

        // Determines whether the specified object is equal to the current object.
        public override bool Equals(Object? obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                AvailableBalance e = (AvailableBalance)obj;
                return Entity.PropertyEquality(e.BalanceAmount, BalanceAmount) &&
                    Entity.PropertyEquality(e.DateAsOf, DateAsOf);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { BalanceAmount, DateAsOf }.GetHashCode();
    }
}