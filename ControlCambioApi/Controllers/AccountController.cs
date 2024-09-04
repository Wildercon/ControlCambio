using ControlCambioApi.Models;
using ControlCambioApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlCambioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAccountAll()
        {
            return Ok(await _accountService.GetAccountAsync());
        }

        [HttpPost]
        public async Task<bool> AddAccount(Account account)
        {
            return await _accountService.AddAccount(account);
        }

        [HttpPut]
        public async Task<bool> UpdateAccount(Account account)
        {
            return await _accountService.UpdateAccount(account);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAccount(int id)
        {
            return await _accountService.DeleteAccount(id);
        }

    }
}
