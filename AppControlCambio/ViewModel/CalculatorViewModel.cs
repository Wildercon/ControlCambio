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
        public CalculatorViewModel()
        {
            CalculateCommand = new Command<string>(OnCalculate);
        }
       
        private string op;
        [ObservableProperty]
        private decimal tasa;

        public ICommand CalculateCommand { get; }
        [ObservableProperty]
        private decimal resultCal;
    
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            op = query["op"].ToString();
            Tasa = decimal.Parse(query["tasa"].ToString());
            
        }


        private void OnCalculate(string mont)
        {
            if (mont == string.Empty) {
                ResultCal = 0;
                return; }
            var monto = decimal.Parse(mont);
            ResultCal = op == "*" ? monto * Tasa : monto / Tasa;
           
        }

       
    }
}
