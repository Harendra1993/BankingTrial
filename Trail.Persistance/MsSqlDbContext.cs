using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Trail.Api.DbModels;
using Trail.Persistance.Mappings;
using Trail.Persistance.Seeders;

namespace Trail.Persistance
{
    public class MsSqlDbContext: DbContext
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
        {

        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AccountMapping());
            builder.ApplyConfiguration(new TransactionMapping());

            builder.ApplyConfiguration(new AccountSeeder());
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            if (!dbContextBuilder.IsConfigured)
            {
                dbContextBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
            base.OnConfiguring(dbContextBuilder);
        }
    }
}
