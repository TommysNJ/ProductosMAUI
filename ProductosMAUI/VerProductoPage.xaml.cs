using ProductosMAUI.Models;

namespace ProductosMAUI;

public partial class VerProductoPage : ContentPage
{

	private Producto _producto;

    public VerProductoPage()
	{
		InitializeComponent();
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
        Utils.Util.ListaProductos.Remove(_producto);
        await Navigation.PopModalAsync();
    }

    private async void OnClickEditar(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NuevoProductoPage()
        {
            BindingContext = _producto,
        });
    }
}
