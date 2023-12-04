namespace MauiApp1;
//using Syncfusion.Maui.Core.Hosting;
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
    private async void AddNewDog_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/AddDogPage");
    }

    private async void ChangeAccount_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/LoginPage");
    }
    private async void LastDogs_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/SessionSummaryPage");
    }

    private void ShowSettings_Clicked(object sender, EventArgs e)
    {
        if (SettingsFrame.IsVisible)
        {
            SettingsFrame.IsVisible = false;
            SettingsButton.Text = "Show Settings";
        }
        else
        {
            SettingsFrame.IsVisible = true;
            SettingsButton.Text = "Hide Settings";
        }
    }
}