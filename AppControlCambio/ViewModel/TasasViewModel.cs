
using AppControlCambio.Pages;
using AppControlCambio.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppControlCambio.ViewModel
{
    public partial class TasasViewModel : ObservableObject , IQueryAttributable
    {
        private readonly ITasaService _tasaService;
        [ObservableProperty]
        private List<ResponseTasas> listaTasas = new();
        [ObservableProperty]
        private string titulo;
        [ObservableProperty]
        private bool activityIndicator = false;

        private int selectedPorcentaje = 0;

        public int SelectedPorcentaje
        {
            get {  return selectedPorcentaje; } 
            
            set
            {
                if (selectedPorcentaje != value)
                {
                    
                    selectedPorcentaje = value;
                    OnPropertyChanged(nameof(SelectedPorcentaje));
                    MainThread.BeginInvokeOnMainThread(new Action(async () => await GetTasas()));
                    
                }
            }
        }
        
        
        private string pais;
        
        
        public  TasasViewModel(ITasaService tasaService )
        {
            _tasaService = tasaService;
            MainThread.BeginInvokeOnMainThread(new Action(async () => await GetTasas()));
        }
        
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            pais = query["pais"].ToString();
            Titulo = pais;          
        }

        public async Task GetTasas()
        {
            ActivityIndicator = true;        
            while(pais == null)
            {
                await Task.Delay(10);
            }

            ListaTasas = await _tasaService.GetTasas(pais, selectedPorcentaje);
            ActivityIndicator = false;
        }

        [RelayCommand]
        private async Task Calculator(ResponseTasas por)
        {
            var url = $"{nameof(Calculator)}?tasa={por.tasa}&op={por.op}";
            await Shell.Current.GoToAsync(url);

        }
    }
}
