
using AppControlCambio.Pages;
using AppControlCambio.Service;
using CommunityToolkit.Maui.Core.Extensions;
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
        private List<AccountDTO> listAccount = [];
        
        
        private readonly IAccountService _AccountService;
        
        public AccountViewModel(IAccountService accountService) {
            _AccountService = accountService;
                    
            MainThread.BeginInvokeOnMainThread(new Action(async () => ListAccount = await accountService.GetAccounts()));
          
        }

        

        [RelayCommand]

        public async Task PageAddAccount()
        {
            var result = await Shell.Current.DisplayPromptAsync("Autorizacion","Ingrese Codigo");
             if (result == "Wilcon96" || result == "Jhonde22") {
                await Shell.Current.GoToAsync(nameof(AddAccount));
            }
            else
            {
                await Shell.Current.DisplayAlert("Acceso Denegado","Codigo Incorrecto","OK");
            }
        }

        [RelayCommand]
        public async Task EditAccount(AccountDTO account)
        {
            await Shell.Current.GoToAsync(nameof(AddAccount), true, new Dictionary<string, object> { { "Account", account }});
        }
        [RelayCommand]
        public async Task DeleteAccount(int id)
        {
            var aResult = await Shell.Current.DisplayAlert("Eliminar", "Desea eliminar la cuenta?", "Si", "No");
            if (aResult)
            {
                var result = await _AccountService.DeleteAccount(id);

                if (result)
                {
                    await Shell.Current.DisplayAlert("Procesado", "Cuenta Eliminada", "Aceptar");
                    MainThread.BeginInvokeOnMainThread(new Action(async () => ListAccount = await _AccountService.GetAccounts()));
                }       
                else
                    await Shell.Current.DisplayAlert("Error", "No se pudo realizar,Intente de nuevo","Aceptar");
            }
            
        }

        [RelayCommand]
        public static async Task ClipboardAccount(AccountDTO account)
        { 
            var dato = $"Pais:{account.Country}\nTitular:{account.Name}\nCuenta:{account.AccountNumber}";
            if (account.IdOwner != string.Empty) dato +=  $"\nIdentificación: { account.IdOwner}";
            if(account.Bank != string.Empty) dato +=  $"\nBanco:{account.Bank}";
            if(account.Observation != string.Empty)dato += $"\nObservación:{account.Observation}";
            await Clipboard.SetTextAsync(dato);
            await Shell.Current.DisplayAlert("", "Cuenta Copiada", "Ok");
        }
    }
}
