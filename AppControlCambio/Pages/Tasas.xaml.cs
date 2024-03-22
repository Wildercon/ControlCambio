
using AppControlCambio.ViewModel;
using Shared;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace AppControlCambio.Pages;

public partial class Tasas : ContentPage
{


    private string urlApi = "http://tasasapi.somee.com/api/Tasa";
    public Tasas(TasasViewModel model )
	{ 
		InitializeComponent();
        BindingContext = model;
	}

    

   
    public async Task GetTasas(string nombre)
    {
        var client = new HttpClient();
        var response = await client.GetAsync(urlApi);
        var responseBody = await response.Content.ReadAsStringAsync();

        var Tasas = JsonSerializer.Deserialize<List<ResponseTasas>>(responseBody);
        //listViewTasas.ItemsSource =  Tasas;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await GetTasas("Venezuela");
    }
}