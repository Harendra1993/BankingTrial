using Microsoft.EntityFrameworkCore;
using Trail.Api.DbModels;
using Trail.Persistance;

namespace Trail.Api.Services
{
    public class Service:IService
    {
        protected MsSqlDbContext context;
        public Service(MsSqlDbContext context)
        {
            this.context = context;
        }

        public async Task AddTransaction(Transaction entity)
        {
            context.Set<Transaction>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Account> Deposit(Transaction entity)
        {
            Account account = context.Accounts.FirstOrDefault(a => a.AccountNumber == entity.AccountNumber);
            if (account != null)
            {
                account.Balance += entity.Amount;
                context.Entry(account).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }

            return account;
        }

        public async Task<Account> Withdraw(Transaction entity)
        {
            Account account = context.Accounts.FirstOrDefault(a => a.AccountNumber == entity.AccountNumber);
            if (account?.Balance >= entity.Amount)
            {
                account.Balance -= entity.Amount;
                context.Entry(account).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            return account;
        }

        public async Task<Account> Balance(int accountNumber)
        {
            return await context.FindAsync<Account>(accountNumber);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}