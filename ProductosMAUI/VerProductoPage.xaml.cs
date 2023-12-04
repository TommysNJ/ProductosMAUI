using ProductosMAUI.Models;
using ProductosMAUI.Services;

namespace ProductosMAUI;

public partial class VerProductoPage : ContentPage
{

	private Producto _producto;
    private APIService _APIService;

    public VerProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        Nombre.Text = _producto.Nombre;
        Cantidad.Text = _producto.cantidad.ToString();
        Descripcion.Text = _producto.Descripcion;
    }

    private async void OnClickVolver(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}

    private async void OnClickEliminar(object sender, EventArgs e)
    {
        await _APIService.DeleteProducto(_producto.IdProducto);
        await Navigation.PopModalAsync();
        /*Utils.Util.ListaProductos.Remove(_producto);
        await Navigation.PopModalAsync();*/
    }

    private async void OnClickEditar(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NuevoProductoPage(_APIService)
        {
            BindingContext = _producto,
        });
    }
}
