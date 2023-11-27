using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductosMAUI.Models;

namespace ProductosMAUI;

public partial class ProductoPage : ContentPage
{
	public ProductoPage()
	{
		InitializeComponent();
        
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var productos = new ObservableCollection<Producto>(Utils.Util.ListaProductos);
        listaProductos.ItemsSource = productos;
    }


    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NuevoProductoPage());
    
    }

    private async void OnClickVerProducto(object sender, SelectedItemChangedEventArgs e)
    {
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushModalAsync(new VerProductoPage(){
            BindingContext = producto,
        });

    }

   
}
