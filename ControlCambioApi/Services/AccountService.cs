using ControlCambioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlCambioApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly TasasDbContext _dbContext;

        public AccountService(TasasDbContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public async Task<bool> AddAccount(Account account)
        {
           _dbContext.Accounts.Add(account);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var account =  _dbContext.Accounts.FirstOrDefault(x => x.Id == id);
             _dbContext.Accounts.Remove(account!);

            return await _dbContext.SaveChangesAsync() > 0; 
        }

        public async Task<List<Account>> GetAccountAsync()
        {
            return await _dbContext.Accounts.ToListAsync();

        }
        public async Task<bool> UpdateAccount(Account account)
        {
             _dbContext.Accounts.Update(account) ;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
