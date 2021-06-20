using System.Collections.Generic;

namespace XayahFinances.Domain.Entities
{
    public class BankAccount : Entity
    {
        public string BankId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
