namespace MauiApp1;

public partial class TrainingPage : ContentPage
{
	public TrainingPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        PlanFrame.IsVisible = MyAccount.Contact.IsTrainer;
        PlanLabel.IsVisible = MyAccount.Contact.IsTrainer;
    }
    private async void StartSession_Clicked(object sender, EventArgs e)

    {
        if (MyAccount.Contact.IsTrainer)
        {
            await Shell.Current.GoToAsync($"/StartSessionPage");
        }
        else
        {
            await Shell.Current.GoToAsync($"/StartSessionPage");
        }
        

    }

    private async void PlanSession_Clicked(object sender, EventArgs e)

    {

        await Shell.Current.GoToAsync($"/PlanSession");

    }
    private async void Tricks_Clicked(object sender, EventArgs e)

    {

        await Shell.Current.GoToAsync($"/Tricks");

    }
    private async void DetailSessions_Clicked(object sender, EventArgs e)

    {
        await Shell.Current.GoToAsync($"/DetailSessions");


    }
}