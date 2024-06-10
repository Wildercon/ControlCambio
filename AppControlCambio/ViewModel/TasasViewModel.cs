
using AppControlCambio.Pages;
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
        private readonly HttpClient _httpClient;
        [ObservableProperty]
        private ObservableCollection<ResponseTasas> listaTasas = new();
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
        
        
        public  TasasViewModel( HttpClient httpClient)
        {
            _httpClient = httpClient;
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
          
            var response = await _httpClient.GetAsync($"Tasa/Tasas/{pais}?por={selectedPorcentaje}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var lista = JsonSerializer.Deserialize<List<ResponseTasas>>(responseBody);
            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    ListaTasas.Add(new ResponseTasas
                    {
                        pais = item.pais,
                        tasa = item.tasa,
                        op = item.op,
                        porcentaje = item.porcentaje,
                    });
                }
            }
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
