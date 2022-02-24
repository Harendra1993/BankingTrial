using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trail.Api.DbModels;

namespace Trail.Persistance.Mappings
{
    internal class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.AccountNumber);
            builder.Property(x => x.AccountNumber).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Balance).HasPrecision(12,4).IsRequired();
        }
    }
}
