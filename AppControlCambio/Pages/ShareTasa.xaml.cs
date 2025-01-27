using AppControlCambio.ViewModel;

namespace AppControlCambio.Pages;

public partial class ShareTasa : ContentPage
{
	public ShareTasa(ShareTasaVM model)
	{
		InitializeComponent();
		BindingContext = model;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Verificamos si el ViewModel tiene un m�todo para manejar la l�gica despu�s de cargar.
        if (BindingContext is ShareTasaVM viewModel)
        {
            ShareTasaVM.OnAppearing();
        }
    }
}