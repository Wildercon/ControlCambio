
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppControlCambio.Service
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        public AccountService(HttpClient httpClient) {
            _httpClient = httpClient;
        }


        public async Task<List<Account>> GetAccounts()
        {
            var response = await _httpClient.GetAsync($"Account");
            var responseBody = await response.Content.ReadAsStringAsync();

            var Accounts = JsonSerializer.Deserialize<List<Account>>(responseBody);

            return Accounts;
        }


    }
}
