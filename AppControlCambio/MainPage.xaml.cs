using AppControlCambio.Pages;
using AppControlCambio.ViewModel;

namespace AppControlCambio
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(MainPageViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

        
    }
}