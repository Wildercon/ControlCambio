
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppControlCambio.Service
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;
        public AccountService(HttpClient httpClient, JsonSerializerOptions serializerOptions)
        {
            _httpClient = httpClient;
            _serializerOptions = serializerOptions;
        }

        public async Task<bool> AddAccount(AccountDTO accountDTO)
        {
            var response =  await _httpClient.PostAsJsonAsync($"Account",accountDTO);
            var responseBody = await response.Content.ReadAsStringAsync();
            return Convert.ToBoolean(responseBody);

        }

        public async Task<List<AccountDTO>> GetAccounts()
        {
            
            var response = await _httpClient.GetAsync("Account");
            var responseBody = await response.Content.ReadAsStringAsync();

            return  JsonSerializer.Deserialize<List<AccountDTO>>(responseBody, _serializerOptions);

           
        }

        public async Task<bool> UpdateAccount(AccountDTO accountDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("Account",accountDTO);
            var responseBody = await response.Content.ReadAsStringAsync();
            return Convert.ToBoolean(responseBody);
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var response = await _httpClient.DeleteAsync($"Account/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return Convert.ToBoolean(responseBody);
        }
    }
}
