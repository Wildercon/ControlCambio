using AppControlCambio.ViewModel;

namespace AppControlCambio.Pages;

public partial class UpdateTasas : ContentPage
{
	public UpdateTasas( UpdateTasasView updateTasasView)
	{
		InitializeComponent();
		BindingContext = updateTasasView;
	}
}