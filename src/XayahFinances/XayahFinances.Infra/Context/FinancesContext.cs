using Microsoft.EntityFrameworkCore;
using XayahFinances.Domain.Entities;

namespace XayahFinances.Infra.Context
{
    public class FinancesContext : DbContext
    {
        public FinancesContext() { }

        public FinancesContext(DbContextOptions<FinancesContext> options)
            : base(options)
        {

        }

        public DbSet<BankAccount> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
