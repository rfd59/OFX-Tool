using System;

namespace RFD.OFXTool.Library.Entities
{
    public class Transaction
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public double TransactionValue { get; set; }

        public string Id { get; set; }

        public string Description { get; set; }

        public long Checksum { get; set; }

    }
}
