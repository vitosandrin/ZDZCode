using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                   .IsRequired()
                   .ValueGeneratedNever();

            builder.Property(t => t.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Date)
                   .IsRequired();

            builder.Property<Guid>("AccountId")
                   .IsRequired();
        }
    }
}
