namespace MauiApp1;

public partial class SessionPage : ContentPage
{
    public ViewSession View { get; set; } = MyAccount.Session;
    public SessionPage()
	{
		InitializeComponent();
        BindingContext = View;
    }


    private void Good_Tapped(object sender, TappedEventArgs e)
    {
		if(View.SelectedTrick != null) 
        {
            View.SelectedTrick.TrickGood();
        }
    }

    private void Bad_Tapped(object sender, TappedEventArgs e)
    {
        if (View.SelectedTrick != null)
        {
            View.SelectedTrick.TrickBad();
        }
    }


    private async void End_Pressed(object sender, EventArgs e)
    {
        View.EndTime= DateTime.Now;
        TimeSpan ts = View.EndTime - View.StartTime;
        View.Minutes= ts.Minutes;
        View.Hours= ts.Hours;
        
        await Shell.Current.GoToAsync($"/SessionSummaryPage");
    }
}