using Account.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infraestructure.Data.Mapping
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(p => p.Account)
                .WithOne(i => i.User)
                .HasForeignKey<Account>(b => b.UserId);

            builder.Property(e => e.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Phone)
                .HasColumnType("varchar(15)")
                .IsRequired();
        }
    }
}
