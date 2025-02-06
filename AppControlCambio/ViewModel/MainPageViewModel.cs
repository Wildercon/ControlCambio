
using AppControlCambio.Pages;
using AppControlCambio.Service;
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
        private readonly ITasaService _tasaService;
        [ObservableProperty]
        private List<TasasPDTO> listaPais = [];
        [ObservableProperty]
        private bool activityIndicator = false;

        [RelayCommand]
        private async Task Tasas(string pais)
        {
            var url = $"{nameof(Tasas)}?pais={pais}";
            await Shell.Current.GoToAsync(url);

        }

        
        public MainPageViewModel(ITasaService tasaService)
        {
            _tasaService = tasaService;
            activityIndicator = true;
            MainThread.BeginInvokeOnMainThread(new Action(async () =>  ListaPais = await tasaService.GetCountries()));
            
            activityIndicator = false;
        }

       
    }
}
