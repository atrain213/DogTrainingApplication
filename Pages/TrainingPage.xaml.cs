namespace MauiApp1;

public partial class TrainingPage : ContentPage
{
	public TrainingPage()
	{
		InitializeComponent();
	}
    private async void NewSession_Clicked(object sender, EventArgs e)

    {

        await Shell.Current.GoToAsync($"/NewSession");

    }
}