using ControlCambioApi.Models;

namespace ControlCambioApi.Services
{
    public interface IAccountService
    {
        Task<List<Account>> GetAccountAsync();
        Task<bool> AddAccount(Account account);
        Task<bool> UpdateAccount(Account account);
        Task<bool> DeleteAccount(int id);
    }
}
