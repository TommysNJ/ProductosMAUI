using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductosMAUI.Models;
using ProductosMAUI.Services;

namespace ProductosMAUI;

public partial class ProductoPage : ContentPage
{
    ObservableCollection<Producto> products;
    private readonly APIService _APIService;

	public ProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
        
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<Producto> ListaProducts = await _APIService.GetProductos();
        products = new ObservableCollection<Producto>(ListaProducts);
        listaProductos.ItemsSource = products;

        /*var productos = new ObservableCollection<Producto>(Utils.Util.ListaProductos);
        listaProductos.ItemsSource = productos;*/
    }


    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {
        //await Navigation.PushModalAsync(new NuevoProductoPage());
        await Navigation.PushModalAsync(new NuevoProductoPage(_APIService));
    
    }

    private async void OnClickVerProducto(object sender, SelectedItemChangedEventArgs e)
    {
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushModalAsync(new VerProductoPage(_APIService){
            BindingContext = producto,
        });

    }

   
}
