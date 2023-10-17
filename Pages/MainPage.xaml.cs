namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public ViewDogList View { get; set; } = new();

	public MainPage()
	{
		InitializeComponent();
		Refresh();
		BindingContext = View;
	}

public async void Refresh()
	{
		await View.loadAPI();
	}	
}


