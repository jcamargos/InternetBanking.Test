using Account.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infraestructure.Data.Mapping
{
    public class CheckingAccountConfiguration : IEntityTypeConfiguration<CheckingAccount>
    {
        public void Configure(EntityTypeBuilder<CheckingAccount> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Balance)
                .HasDefaultValue(0.00);
        }
    }
}
