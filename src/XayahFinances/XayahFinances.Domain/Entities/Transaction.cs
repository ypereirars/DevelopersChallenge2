using System;

namespace XayahFinances.Domain.Entities
{
    public class Transaction : Entity
    {
        public string Type { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public long BankAccountId { get; set; }
    }
}
