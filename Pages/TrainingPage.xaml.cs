namespace MauiApp1.Pages;

public partial class TrainingPage : ContentPage
{
	public TrainingPage()
	{
		InitializeComponent();
	}
    private async void NewSession_Clicked(object sender, EventArgs e)

    {

        await Navigation.PushAsync(new NewSession());

    }
}