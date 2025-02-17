using AppControlCambio.ViewModel;
using CommunityToolkit.Maui.Views;

namespace AppControlCambio.Pages;

public partial class Calculator : Popup
{
	public Calculator(decimal Tasa,string Op,string MonedaR,string MonedaE)
	{
		InitializeComponent();
		 
		
		BindingContext = new CalculatorViewModel { Tasa = Tasa, Op = Op,MonedaR = MonedaR,MonedaE = MonedaE ,ResultCal= Op.Equals('*') ? Tasa : 1 ,ResultCalE = Op.Equals('*') ? 1 : Tasa };
		
	}
}