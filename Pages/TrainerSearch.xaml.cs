namespace MauiApp1;

public partial class TrainerSearch : ContentPage
{
	public TrainerSearch()
	{
		InitializeComponent();
	}
    private async void Bio_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/TrainerBioPage");
    }
}