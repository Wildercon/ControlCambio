

using AppControlCambio.Pages;
using AppControlCambio.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Reflection;

using Shared;
using Microsoft.Maui.Graphics.Platform;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;






namespace AppControlCambio.ViewModel
{
    public partial class TasasViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private IDrawable drawable;
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
            MainThread.BeginInvokeOnMainThread(new Action(async () =>
            {
                await GetTasas(); // Esperar a que se llene ListaTasas.
                Drawable = new CustomDrawable(ListaTasas, pais); // Solo crear después de obtener las tasas.
                
            }));
            
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

        #region Download tasas

        private async void DownloadTasas()
        {
            while (ListaTasas.Count == 0) await Task.Delay(10);
        }




        //Clase que implementa IDrawable para manejar el dibujo
        public class CustomDrawable(List<ResponseTasas> listTasas, string country) : IDrawable
        {

            public  void Draw(ICanvas canvas, Microsoft.Maui.Graphics.RectF dirtyRect)
            {

                Assembly assembly = GetType().GetTypeInfo().Assembly;
                using Stream stream = assembly.GetManifestResourceStream("AppControlCambio.Resources.Images.changetasas.png");
                var _image = PlatformImage.FromStream(stream);
                canvas.DrawImage(_image, 0, 0, dirtyRect.Width, 550);
                canvas.FontSize = 30;
                canvas.FontColor = Colors.Black;
                canvas.Font = Microsoft.Maui.Graphics.Font.DefaultBold;
                canvas.DrawString($"envia desde\n   {country}",80,150,HorizontalAlignment.Left);
                using Stream stream1 = assembly.GetManifestResourceStream($"AppControlCambio.Resources.Images.{country}t.png");
                var _image1 = PlatformImage.FromStream(stream1);
                canvas.DrawImage(_image1, 80, 200, 150, 150);
                canvas.FontSize = 24;
                canvas.Font = Microsoft.Maui.Graphics.Font.DefaultBold;

                var image = 100;
                var text = 127;
                foreach (var tasa in listTasas)
                {
                    if (tasa.tasa != "No Registrada")
                    {
                        using Stream stream2 = assembly.GetManifestResourceStream($"AppControlCambio.Resources.Images.{tasa.pais}t.png");

                        var _image2 = PlatformImage.FromStream(stream2);

                        canvas.DrawImage(_image2, 355, image, 30, 30);
                        canvas.DrawString(tasa.tasa, 340, text, HorizontalAlignment.Right);// Dibuja el texto sobre la imagen
                        image += 50;
                        text += 50;
                    }
                   
                }
                

            }


            
        }
        #endregion
    }
}