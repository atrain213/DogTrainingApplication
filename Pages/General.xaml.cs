namespace MauiApp1;

public partial class General : ContentPage
{
	public General()
	{
       InitializeComponent();
	}

    private async void TrainerSearch_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/TrainerSearch");
    }
    private async void AccountPage_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/AccountPage");
    }
    private async void SettingsPage_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/SettingsPage");
    }
    private async void DataExportPage_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/DataExportPage");
    }
}