using AppControlCambio.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using Microsoft.Maui.Controls;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControlCambio.ViewModel
{
    [QueryProperty(nameof(Account),"Account")]
    public partial class AddAccountVM : ObservableObject
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<AccountDTO> _validator;
        [ObservableProperty]
        private List<TasasPDTO> listTasas = [];
        [ObservableProperty]
        private List<string> listCountry = [];



        [ObservableProperty]
        private AccountDTO account = new(0,string.Empty, string.Empty, string.Empty, string.Empty,string.Empty,string.Empty);

        public AddAccountVM(IAccountService accountService, ITasaService tasaService, IValidator<AccountDTO> validator)
        {
            _accountService = accountService;
            _validator = validator;
            MainThread.BeginInvokeOnMainThread(new Action(async () => { ListTasas = await tasaService.GetCountries(); ListCountry = ListTasas.Select(x => x.Pais).ToList(); }));
            
        }

        [RelayCommand]
        private async Task AddAccount()
        {
            var vResult = _validator.Validate(Account);
            bool result;
            if (!vResult.IsValid) {
                await AppShell.Current.DisplayAlert("", vResult.Errors[0].ToString(), "Aceptar");
                return;
            }           
           
            if (Account.Id == 0)
                result = await _accountService.AddAccount(Account);
            else
                result = await _accountService.UpdateAccount(Account);


            if (result)
                await AppShell.Current.DisplayAlert("Exitoso", "Operación Realizada", "Aceptar");
            else
                await AppShell.Current.DisplayAlert("Error", "No se pudo realizar la operación", "Aceptar");


            await AppShell.Current.GoToAsync(nameof(Pages.Account));
        }

       



    }

    
}
