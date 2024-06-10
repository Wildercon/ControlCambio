
using AppControlCambio.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControlCambio.ViewModel
{
    public partial class AccountViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Account> listaAccount = new ObservableCollection<Account>();
        [ObservableProperty]
        private bool activityIndicator = true;
        private readonly IAccountService _AccountService;
        
        public AccountViewModel(IAccountService accountService) {
            _AccountService = accountService;
        }

        [RelayCommand]
        public async Task GetAccount()
        {
            var lista = await _AccountService.GetAccounts();

            if (lista.Any())
            {
                foreach (var account in lista)
                {
                    ListaAccount.Add(new Account
                    {
                        Name = account.Name,
                        AccountNumber = account.AccountNumber,
                        Pais = account.Pais,
                        Mont = account.Mont,


                    });
                        
                        
                }
            }
            ActivityIndicator = false;
        }
    }
}
