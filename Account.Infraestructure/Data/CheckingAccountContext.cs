using Microsoft.EntityFrameworkCore;
using Account.Domain.Entity;
using Account.Infraestructure.Data.Mapping;
using System.Linq;

namespace Account.Infraestructure.Data
{
    public class CheckingAccountContext : DbContext
    {
        private static readonly bool[] _migrated = { false };
        public CheckingAccountContext(DbContextOptions<CheckingAccountContext> options) : base(options)
        {

        }

        public DbSet<CheckingAccount> Accounts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CheckingAccountConfiguration(modelBuilder.Entity<CheckingAccount>());
            new UserConfiguration(modelBuilder.Entity<User>());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
