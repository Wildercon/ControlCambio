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
    public partial class CalculatorViewModel : ObservableObject,IQueryAttributable
    {
                   
        private string op;
        [ObservableProperty]
        private decimal tasa;
        [ObservableProperty]
        private decimal resultCal;
        [ObservableProperty]
        private decimal resultCalE;

        private bool eventA = false;



        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            op = query["op"].ToString();
            Tasa = decimal.Parse(query["tasa"].ToString());
            ResultCal = Tasa;
            ResultCalE = 1;
        }

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
                ResultCal = op == "*" ? monto * Tasa : monto / Tasa;
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
                ResultCalE = op == "*" ? monto / Tasa : monto * Tasa;
            }
        }

    }
}
