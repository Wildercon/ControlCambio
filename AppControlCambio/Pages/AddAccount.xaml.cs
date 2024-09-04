using AppControlCambio.ViewModel;

namespace AppControlCambio.Pages;

public partial class AddAccount : ContentPage
{
	public AddAccount( AddAccountVM addAccountVM)
	{
		InitializeComponent();
		BindingContext = addAccountVM;
		
	}
    protected override bool OnBackButtonPressed()
    {
		 Shell.Current.GoToAsync(nameof(Account));
        return false;
    }
}