using AppControlCambio.Pages;

namespace AppControlCambio
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Tasas), typeof(Tasas));
            Routing.RegisterRoute(nameof(UpdateTasas), typeof(UpdateTasas));
            Routing.RegisterRoute(nameof(Login), typeof(Login));
        }
    }
}