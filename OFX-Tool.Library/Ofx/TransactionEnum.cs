namespace RFD.OFXTool.Library.Ofx
{
    public enum TransactionEnum
    {
        //
        // Résumé :
        //     Generic credit
        CREDIT = 0,
        //
        // Résumé :
        //     Generic debit
        DEBIT = 1,
        //
        // Résumé :
        //     Interest earned or paid
        INT = 2,
        //
        // Résumé :
        //     Dividend
        DIV = 3,
        //
        // Résumé :
        //     FI fee
        FEE = 4,
        //
        // Résumé :
        //     Service charge
        SRVCHG = 5,
        //
        // Résumé :
        //     Deposit
        DEP = 6,
        //
        // Résumé :
        //     ATM debit or credit
        ATM = 7,
        //
        // Résumé :
        //     Point of sale debit or credit
        POS = 8,
        //
        // Résumé :
        //     Transfer
        XFER = 9,
        //
        // Résumé :
        //     Check
        CHECK = 10,
        //
        // Résumé :
        //     Electronic payment
        PAYMENT = 11,
        //
        // Résumé :
        //     Cash withdrawal
        CASH = 12,
        //
        // Résumé :
        //     Direct deposit
        DIRECTDEP = 13,
        //
        // Résumé :
        //     Merchant initiated debit
        DIRECTDEBIT = 14,
        //
        // Résumé :
        //     Repeating payment/standing order
        REPEATPMT = 15,
        //
        // Résumé :
        //     Only valid in Aspose.Finance.Ofx.PendingTransaction; indicates the amount is
        //     under a hold
        HOLD = 16,
        //
        // Résumé :
        //     Other
        OTHER = 17
    }
}
