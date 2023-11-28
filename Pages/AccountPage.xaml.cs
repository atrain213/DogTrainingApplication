namespace MauiApp1;

public partial class AccountPage : ContentPage
{
	public AccountPage()
	{
		InitializeComponent();
	}
    private async void HomePage_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/HomePage");
    }

    private async void AddDog_Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/AddDogPage");
    }
    private async void Bio_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/TrainerBioPage");
    }
}