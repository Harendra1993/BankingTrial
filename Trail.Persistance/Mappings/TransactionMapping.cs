using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trail.Api.DbModels;

namespace Trail.Persistance.Mappings
{
    internal class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Account).WithMany(x=>x.Transactions).HasForeignKey(x=>x.AccountNumber);
            builder.Property(x => x.Amount).HasPrecision(12,4).IsRequired();
            builder.Property(x => x.Currency).IsRequired().HasMaxLength(3);
        }
    }
}
