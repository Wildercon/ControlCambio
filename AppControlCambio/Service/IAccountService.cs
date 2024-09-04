
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControlCambio.Service
{
    public interface IAccountService
    {
        Task<List<AccountDTO>> GetAccounts();
        Task<bool> AddAccount(AccountDTO accountDTO);
        Task<bool> UpdateAccount(AccountDTO accountDTO);
        Task<bool> DeleteAccount(int id);
    }
}
