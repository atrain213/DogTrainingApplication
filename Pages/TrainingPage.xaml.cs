namespace MauiApp1;

public partial class TrainingPage : ContentPage
{
	public TrainingPage()
	{
		InitializeComponent();
	}
    private async void StartSession_Clicked(object sender, EventArgs e)

    {

        await Shell.Current.GoToAsync($"/StartSession");

    }
    private async void NewSession_Clicked(object sender, EventArgs e)

    {

        await Shell.Current.GoToAsync($"/NewSession");

    }
    private async void PlanSession_Clicked(object sender, EventArgs e)

    {

        await Shell.Current.GoToAsync($"/PlanSession");

    }
    private async void Tricks_Clicked(object sender, EventArgs e)

    {

        await Shell.Current.GoToAsync($"/Tricks");

    }
    private async void DetailSession_Clicked(object sender, EventArgs e)

    {
        await Shell.Current.GoToAsync($"/DetailSessions");


    }
}