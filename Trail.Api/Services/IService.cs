using Trail.Api.DbModels;
using Trail.Api.Models.ViewModels;

namespace Trail.Api.Services
{
    public interface IService
    {
        Task AddTransaction(Transaction entity);
        Task<Account> Deposit(Transaction entity);
        Task<Account> Withdraw(Transaction entity);
        Task<Account> Balance(int accountNumber);
        Task SaveChangesAsync();
    }
}
