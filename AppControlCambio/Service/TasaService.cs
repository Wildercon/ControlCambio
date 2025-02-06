using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace AppControlCambio.Service
{
    public class TasaService(HttpClient httpClient , JsonSerializerOptions jsonSerializer) : ITasaService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly JsonSerializerOptions _serializerOptions = jsonSerializer;

        public async Task<List<TasasPDTO>> GetCountries()
        {
           
            var response = await _httpClient.GetAsync("Tasa/Paises");
            var responseBody = await response.Content.ReadAsStringAsync();

           return JsonSerializer.Deserialize<List<TasasPDTO>>(responseBody,_serializerOptions); 
                      
           
        }

        public async Task<List<ResponseTasas>> GetTasas(string pais,int porcentaje)
        {
            List<ResponseTasas> ListaTasas = [];
            var response = await _httpClient.GetAsync($"Tasa/Tasas/{pais}?por={porcentaje}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ResponseTasas>>(responseBody);
            
        }

        public async Task<bool> UpdateTasas(TasasPDTO tasa)
        {
            var response = await _httpClient.PutAsJsonAsync("http://tasasapi.somee.com/api/Tasa", tasa);
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(responseBody);
        }
    }
}
