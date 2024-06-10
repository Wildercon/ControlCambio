using AppControlCambio.Pages;
using AppControlCambio.Service;
using AppControlCambio.ViewModel;
using CommunityToolkit.Maui;
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
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MerriweatherSans.ttf", "MerriweatherSans");
                });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://tasasapi.somee.com/api/") });

            builder.Services.AddTransient<Tasas>();
            builder.Services.AddTransient<TasasViewModel>();


            builder.Services.AddTransient<MainPage> ();
            builder.Services.AddTransient<MainPageViewModel>();

            builder.Services.AddTransient<UpdateTasas>();
            builder.Services.AddTransient<UpdateTasasView>();

            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<LoginViewModel>();

            builder.Services.AddTransient<Calculator>();
            builder.Services.AddTransient<CalculatorViewModel>();

            builder.Services.AddTransient<Account>();
            builder.Services.AddTransient<AccountViewModel>();

            builder.Services.AddScoped<IAccountService,AccountService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}