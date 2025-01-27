
using AppControlCambio.ViewModel;
using Shared;
using SkiaSharp.Views.Maui;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace AppControlCambio.Pages;

public partial class Tasas : ContentPage
{


    public Tasas(TasasViewModel model )
	{ 
		InitializeComponent();
        BindingContext = model;
        
    }


}