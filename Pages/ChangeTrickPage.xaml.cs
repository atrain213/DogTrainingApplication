namespace MauiApp1;

public partial class ChangeTrickPage : ContentPage
{
	public ChangeTrickPage()
	{
		InitializeComponent();
	}

    private async void TrickPicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"..");
    }
}