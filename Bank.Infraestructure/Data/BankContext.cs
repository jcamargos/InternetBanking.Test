using Bank.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bank.Infraestructure.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }
        public DbSet<Transfer> TransferReleases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TransferConfiguration(modelBuilder.Entity<Transfer>());
            
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

        }
    }
}
