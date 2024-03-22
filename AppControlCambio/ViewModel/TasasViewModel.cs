
using CommunityToolkit.Mvvm.ComponentModel;
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

        private string urlApi = "http://tasasapi.somee.com/api/Tasa";
        [ObservableProperty]
        private ObservableCollection<ResponseTasas> listaTasas = new ObservableCollection<ResponseTasas>();
        [ObservableProperty]
        private string titulo;
        
        
        private string pais;
        
        
        public  TasasViewModel()
        {
            MainThread.BeginInvokeOnMainThread(new Action(async () => await GetTasas(pais)));
        }
        
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            pais = query["pais"].ToString();
            Titulo = pais;          
        }

        public async Task GetTasas(string ps)
        {
                     
            while(pais == null)
            {
                await Task.Delay(10);
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{urlApi}/{pais}");
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
                    });
                }
            }

        }
    }
}
