using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppControlCambio.ViewModel
{
    public partial class CalculatorViewModel : ObservableObject
    {
        [ObservableProperty]
        private string op;
        [ObservableProperty]
        private decimal tasa;
        [ObservableProperty]
        private decimal resultCal;
        [ObservableProperty]
        private decimal resultCalE;
        [ObservableProperty]
        private string monedaR;
        [ObservableProperty]
        private string monedaE;
        

        private bool eventA = false;

        [RelayCommand]
        private void OnCalculate(string mont)
        {
            if (mont is null) return;
            if (mont == string.Empty)
            {
                eventA = false;
                return;
            }
               

            if (!eventA)
            {
                var monto = decimal.Parse(mont);
                var result = Op == "*" ? monto * Tasa : monto / Tasa;
                ResultCal = decimal.Round(result, 2);
            }
            
        }

        [RelayCommand]
        private void OnCalculateR(string mont)
        {
            if (mont is null) return;
            if (mont == string.Empty)
            {
                eventA = true;
                return;
            }
                
           
            if (eventA)
            {
                var monto = decimal.Parse(mont);
                var result = Op == "*" ? monto / Tasa : monto * Tasa;
                ResultCalE = decimal.Round(result,2);
            }
        }
        [RelayCommand]
        public static async Task ClipboardMont(string mont)
        {
           
            await Clipboard.SetTextAsync(mont);
            await Shell.Current.DisplayAlert("", "Copiado", "Ok");
        }

    }
}
