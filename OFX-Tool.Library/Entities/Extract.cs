using System;
using System.Collections.Generic;

namespace RFD.OFXTool.Library.Entities
{
    public class Extract
    {
        public HeaderExtract Header { get; set; }
        public BankAccount BankAccount { get; set; }
        public string Status { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public IList<string> ImportingErrors { get; private set; }

        public Extract(HeaderExtract header, BankAccount bankAccount,
            string status, DateTime initialDate, DateTime finalDate)
        {
            Init(header, bankAccount, status);
            InitialDate = initialDate;
            FinalDate = finalDate;
        }

        public Extract(HeaderExtract header, BankAccount bankAccount, string status) => Init(header, bankAccount, status);

        private void Init(HeaderExtract header, BankAccount bankAccount, string status)
        {
            Header = header;
            BankAccount = bankAccount;
            Status = status;
            Transactions = new List<Transaction>();
            ImportingErrors = new List<string>();
        }

        public void AddTransaction(Transaction transaction)
        {
            if (Transactions == null)
                Transactions = new List<Transaction>();
            Transactions.Add(transaction);
        }
    }
}
