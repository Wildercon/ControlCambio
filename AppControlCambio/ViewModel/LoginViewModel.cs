using AppControlCambio.Pages;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControlCambio.ViewModel
{
    public partial class LoginViewModel
    {
        [RelayCommand]
        private async Task UpdateTasa(string cod)
        {
            
            if (cod == "Wilcon96" || cod == "Jhondel22")
            {
                await Shell.Current.GoToAsync(nameof(UpdateTasas));
            }
        }
    }
}
