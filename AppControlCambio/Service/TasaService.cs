﻿using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace AppControlCambio.Service
{
    public class TasaService(HttpClient httpClient) : ITasaService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<string>> GetCountries()
        {
            List<string> listCountry = [];
            var response = await _httpClient.GetAsync("Tasa/Paises");
            var responseBody = await response.Content.ReadAsStringAsync();

            var lista = JsonSerializer.Deserialize<List<Pais>>(responseBody); // TODO : Modificar cuando el api solo envia la lista nombre de paises

            if (lista.Count != 0)
            {
                foreach (var item in lista)
                {
                    listCountry.Add(item.pais);

                }
            }
            return listCountry;
        }

        public async Task<List<ResponseTasas>> GetTasas(string pais,int porcentaje)
        {
            List<ResponseTasas> ListaTasas = [];
            var response = await _httpClient.GetAsync($"Tasa/Tasas/{pais}?por={porcentaje}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var lista = JsonSerializer.Deserialize<List<ResponseTasas>>(responseBody);
            if (lista.Count > 0)
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

            return ListaTasas;
        }
    }
}
