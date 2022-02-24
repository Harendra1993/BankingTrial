using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Trail.Api.DbModels;

namespace Trail.Persistance.Seeders
{
    internal class AccountSeeder : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            Random random = new Random();

            List<Account> account=new List<Account>();

            int accountNumber = 10000001;

            for (int i = 0; i < 1000; i++)
            {
                accountNumber += i;
                account.Add(new Account()
                {
                    AccountNumber = accountNumber,
                    Balance = random.Next(0, 50001),
                    Date = DateTime.Now
                });
                
            }

            builder.HasData(account);
        }
    }
}
