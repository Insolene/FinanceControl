using FinanceControl.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Data
{
    public class Banco : DbContext
    {
        public Banco(DbContextOptions<Banco> options) : base(options) { }

        public DbSet<UserEntities> Users { get; set; }
        public DbSet<TransactionEntities> Transactions { get; set; }
        public DbSet<CategoryEntities> Categories { get; set; }
    }
}
