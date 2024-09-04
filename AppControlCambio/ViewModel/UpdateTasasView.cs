using AppControlCambio.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppControlCambio.ViewModel
{
    public partial class UpdateTasasView: ObservableObject
    {
        
        [ObservableProperty]
        private ObservableCollection<Pais> listaPais = new ();

        public UpdateTasasView()
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
                    ListaPais.Add(new Pais { pais = item.pais,valorMoneda= item.valorMoneda});
                    
                }
            }
        }

        [RelayCommand]
        private async Task UpdateTasa(Pais pais)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync("http://tasasapi.somee.com/api/Tasa", pais);
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<bool>(responseBody);

            if (result)
            {
                await Shell.Current.DisplayAlert("Exitoso", "Tasa Actualizada", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Intente de Nuevo", "Ok");
            }
        }
    }
}
