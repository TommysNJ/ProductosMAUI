using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductosMAUI.Models;
using ProductosMAUI.Services;

namespace ProductosMAUI;

public partial class NuevoProductoPage : ContentPage
{
    private Producto _producto;
    private readonly APIService _APIService;

    public NuevoProductoPage(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        if (_producto != null)
        {
            Nombre.Text = _producto.Nombre;
            cantidad.Text = _producto.cantidad.ToString();
            Descripcion.Text = _producto.Descripcion;
        }
    }


    private async void OnClickGuardarProducto(object sender, EventArgs e)
    {
        if (_producto != null)
        {
            _producto.Nombre = Nombre.Text;
            _producto.cantidad = Int32.Parse(cantidad.Text);
            _producto.Descripcion = Descripcion.Text;
            await _APIService.PutProducto(_producto.IdProducto, _producto);
            await Navigation.PopModalAsync();
        } else
        {
            try
            {
                int id = Utils.Util.ListaProductos.Count + 1;
                Producto producto = new Producto
                {
                    IdProducto = 0,
                    Nombre = Nombre.Text,
                    Descripcion = Descripcion.Text,
                    cantidad = Int32.Parse(cantidad.Text)
                };
                await _APIService.PostProducto(producto);
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                var toast = Toast.Make("Error, porfavor ingrese datos del producto.", ToastDuration.Short, 14);
                await toast.Show();
            }
        }
        /*if (_producto != null)
        {
            _producto.Nombre = Nombre.Text;
            _producto.cantidad = Int32.Parse(cantidad.Text);
            _producto.Descripcion = Descripcion.Text;
            await Navigation.PopModalAsync();
        } else
        {
            try
            {
                int id = Utils.Util.ListaProductos.Count + 1;
                Utils.Util.ListaProductos.Add(new Producto
                {
                    IdProducto = id,
                    Nombre = Nombre.Text,
                    Descripcion = Descripcion.Text,
                    cantidad = Int32.Parse(cantidad.Text)
                }
                );
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                var toast = Toast.Make("Error, porfavor ingrese datos del producto.", ToastDuration.Short, 14);
                await toast.Show();
            }
        }*/
        
       
    }
  

    private async void OnClickVolver(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}