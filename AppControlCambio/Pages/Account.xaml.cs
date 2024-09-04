using AppControlCambio.ViewModel;

namespace AppControlCambio.Pages;

public partial class Account : ContentPage
{
	public Account( AccountViewModel accountViewModel)
	{
		InitializeComponent();
		BindingContext = accountViewModel;
	}
}