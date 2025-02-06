using AppControlCambio.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
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
        private readonly ITasaService _tasasService;

        public UpdateTasasView( ITasaService tasaService)
        {
            _tasasService = tasaService;
            MainThread.BeginInvokeOnMainThread(new Action(async () => await ObtenerPaises()));
        }
        private async Task ObtenerPaises()
        {
            var lista =  await _tasasService.GetCountries();

            foreach (var item in lista)
            {
                ListaPais.Add(new Pais { pais = item.Pais, valorMoneda = item.ValorMoneda });

            }

        }

        [RelayCommand]
        private async Task UpdateTasa(Pais pais)
        {
            var tasasP = new TasasPDTO(pais.pais,pais.valorMoneda, DateAndTime.Now.ToString("dd/MM H:mm  tt"),"");
            var result = await _tasasService.UpdateTasas(tasasP);


            if (result)
                await Shell.Current.DisplayAlert("Exitoso", "Tasa Actualizada", "Ok");
            else
                await Shell.Current.DisplayAlert("Error", "Intente de Nuevo", "Ok");

        }
    }
}
