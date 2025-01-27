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
            Routing.RegisterRoute(nameof(Calculator), typeof(Calculator));
            Routing.RegisterRoute(nameof(Account), typeof(Account));
            Routing.RegisterRoute(nameof(AddAccount), typeof(AddAccount));
            Routing.RegisterRoute(nameof(ShareTasa), typeof(ShareTasa));
        }
    }
}