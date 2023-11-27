namespace ProductosMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new ProductoPage();
	}
}

