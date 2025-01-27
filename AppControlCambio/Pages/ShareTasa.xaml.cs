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

        // Verificamos si el ViewModel tiene un método para manejar la lógica después de cargar.
        if (BindingContext is ShareTasaVM viewModel)
        {
            ShareTasaVM.OnAppearing();
        }
    }
}