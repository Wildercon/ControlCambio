using AppControlCambio.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Reflection;

using Shared;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Graphics;
using System.Diagnostics.Metrics;
using SkiaSharp;
using AppControlCambio.Pages;
using System.Threading.Tasks;


namespace AppControlCambio.ViewModel
{
    public partial class TasasViewModel : ObservableObject, IQueryAttributable
    {

        private readonly ITasaService _tasaService;
        [ObservableProperty]
        private List<ResponseTasas> listaTasas = [];
        [ObservableProperty]
        private string titulo;
        [ObservableProperty]
        private bool activityIndicator = false;
        private int selectedPorcentaje = 0;
        public int SelectedPorcentaje
        {
            get { return selectedPorcentaje; }

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
        public string pais;
        


        public TasasViewModel(ITasaService tasaService)
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

            while (pais == null)
            {
                await Task.Delay(10);
            }

            ListaTasas = await _tasaService.GetTasas(pais, selectedPorcentaje);

        }

        [RelayCommand]
        private async Task Calculator(ResponseTasas por)
        {
            var url = $"{nameof(Calculator)}?tasa={por.tasa}&op={por.op}";
            await Shell.Current.GoToAsync(url);

        }
        [RelayCommand]
        private async Task GoShareTasa()
        {
            await Shell.Current.GoToAsync(nameof(ShareTasa), true, new Dictionary<string, object> { { "Tasas", ListaTasas },{"Country",pais } });
        }
        
    }
}
   