using AppControlCambio.ViewModel;

namespace AppControlCambio.Pages;

public partial class Calculator : ContentPage
{
	public Calculator(CalculatorViewModel model )
	{
		InitializeComponent();
		BindingContext = model;
	}
}