using AppControlCambio.ViewModel;

namespace AppControlCambio.Pages;

public partial class Login : ContentPage
{
	public Login( LoginViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}