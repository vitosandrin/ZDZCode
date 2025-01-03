using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                   .IsRequired()
                   .ValueGeneratedNever();

            builder.Property(a => a.AccountNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.Balance)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.HasMany(a => a.Transactions)
                   .WithOne()
                   .HasForeignKey("AccountId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata
                   .FindNavigation(nameof(Account.Transactions))!
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
