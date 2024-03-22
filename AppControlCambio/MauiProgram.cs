using AppControlCambio.Pages;
using AppControlCambio.ViewModel;
using Microsoft.Extensions.Logging;

namespace AppControlCambio
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<Tasas>();
            builder.Services.AddTransient<TasasViewModel>();


            builder.Services.AddTransient<MainPage> ();
            builder.Services.AddTransient<MainPageViewModel>();

            builder.Services.AddTransient<UpdateTasas>();
            builder.Services.AddTransient<UpdateTasasView>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}