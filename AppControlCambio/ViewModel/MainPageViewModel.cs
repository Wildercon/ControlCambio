
using AppControlCambio.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppControlCambio.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Pais> listaPais = new ObservableCollection<Pais>();

        [RelayCommand]
        private async Task Tasas(string pais)
        {
            var url = $"{nameof(Tasas)}?pais={pais}";
            await Shell.Current.GoToAsync(url);

        }

        
        public MainPageViewModel()
        {
            MainThread.BeginInvokeOnMainThread(new Action(async () => await ObtenerPaises()));
        }

        private async Task ObtenerPaises()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://tasasapi.somee.com/api/Tasa/Paises");
            var responseBody = await response.Content.ReadAsStringAsync();

            var lista = JsonSerializer.Deserialize<List<Pais>>(responseBody);

            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    ListaPais.Add(new Pais { pais = item.pais});
                    
                }
            }
        }
    }
}
