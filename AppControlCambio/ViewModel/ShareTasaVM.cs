using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Graphics.Platform;
using Shared;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Font = Microsoft.Maui.Graphics.Font;

namespace AppControlCambio.ViewModel
{
    [QueryProperty(nameof(ListTasas), "Tasas")]
    [QueryProperty(nameof(Country), "Country")]
    public partial class ShareTasaVM : ObservableObject
    {
        [ObservableProperty]
        private IDrawable drawable;
        [ObservableProperty]
        private  List<ResponseTasas> listTasas = [];
        [ObservableProperty]
        private  string country;

        public ShareTasaVM()
        {
            MainThread.BeginInvokeOnMainThread(new Action(async () => {
                await Verify();
                Drawable = new DrawImage(ListTasas, Country);
                
            }));
            
        }

        public static async void OnAppearing()
        {  
            await Task.Delay(200);
           await TakeScreen();
        }
        private async Task<bool> Verify()
        {
            while (ListTasas.Count == 0)
            {
                await Task.Delay(10);
            }
            return true;
        }

        private static async Task TakeScreen()
        {

            if (Screenshot.Default.IsCaptureSupported)
            {
                IScreenshotResult screen = await Screenshot.Default.CaptureAsync();

                Stream stream = await screen.OpenReadAsync();

                // Lee la imagen en un SKBitmap
                using var memStream = new MemoryStream();
                {
                    await stream.CopyToAsync(memStream);
                    memStream.Seek(0, SeekOrigin.Begin);

                    using var bitmap = SKBitmap.Decode(memStream);
                    {
                        // Definir el área a recortar (x, y, ancho, alto)
                        int cropX = 0; // Coordenada X inicial
                        int cropY = 240; // Coordenada Y inicial
                        int cropWidth = 900; // Ancho del recorte
                        int cropHeight = 1000; // Alto del recorte

                        // Verificar que las dimensiones sean válidas
                        cropWidth = Math.Min(cropWidth, bitmap.Width - cropX);
                        cropHeight = Math.Min(cropHeight, bitmap.Height - cropY);

                        // Realizar el recorte
                        var croppedBitmap = new SKBitmap(cropWidth, cropHeight);
                        using (var canvas = new SKCanvas(croppedBitmap))
                        {
                            var srcRect = new SKRectI(cropX, cropY, cropX + cropWidth, cropY + cropHeight);
                            var destRect = new SKRectI(0, 0, cropWidth, cropHeight);
                            canvas.DrawBitmap(bitmap, srcRect, destRect);
                        }

                        // Guardar la imagen recortada
                        var filePath = Path.Combine(FileSystem.CacheDirectory, "captura_recortada.png");
                        using (var image = SKImage.FromBitmap(croppedBitmap))
                        using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                        using (var fileStream = File.OpenWrite(filePath))
                        {
                            data.SaveTo(fileStream);
                        }

                        await Share.Default.RequestAsync(new ShareFileRequest
                        {
                            Title = "Compartir",
                            File = new ShareFile(filePath)
                        });
                    }


                }


            }
        }
    }

    

    public class DrawImage(List<ResponseTasas> listTasas,string country) : IDrawable
    {
        public  void Draw(ICanvas canvas, Microsoft.Maui.Graphics.RectF dirtyRect)
        {

            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using Stream stream = assembly.GetManifestResourceStream("AppControlCambio.Resources.Images.changee.png");
            var _image = PlatformImage.FromStream(stream);
            canvas.DrawImage(_image, 0, 0, dirtyRect.Width-70, 350);
            canvas.FontSize = 26;
            canvas.FontColor = Colors.Black;
            canvas.Font = new Font("Magz.otf");
            canvas.DrawString($"envia desde\n   {country}", 50, 130, HorizontalAlignment.Left);
            using Stream stream1 = assembly.GetManifestResourceStream($"AppControlCambio.Resources.Images.{country}t.png");
            var _image1 = PlatformImage.FromStream(stream1);
            canvas.DrawImage(_image1, 60, 170, 120, 120);
            canvas.FontSize = 20;
            

            var image = 60;
            var text = 77;
            foreach (var tasa in listTasas)
            {
                if (tasa.tasa != "No Registrada")
                {
                    using Stream stream2 = assembly.GetManifestResourceStream($"AppControlCambio.Resources.Images.{tasa.pais}t.png");

                    var _image2 = PlatformImage.FromStream(stream2);

                    canvas.DrawImage(_image2, dirtyRect.Width - 110, image, 20, 20);
                    canvas.DrawString(tasa.tasa, dirtyRect.Width - 125, text, HorizontalAlignment.Right);// Dibuja el texto sobre la imagen
                    image += 30;
                    text += 30;
                }

            }

            
        }
        

    }
}

