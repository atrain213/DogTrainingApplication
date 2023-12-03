namespace MauiApp1;

public partial class SessionSummaryPage : ContentPage
{
    private ViewSession _session = MyAccount.Session;
    public SessionSummaryPage()
	{
		InitializeComponent();
        BindingContext = _session;
    }

    private async void Submit_Clicked(object sender, EventArgs e)
    {
        int retval = await _session.PostDTO();
        if (retval > 0) 
        {
            await Shell.Current.GoToAsync($"../../../");
        }
        //Else Error
        
    }

    private void SetLevel_Clicked(object sender, EventArgs e)
    {
        ImageButton but = (ImageButton)sender;
        ViewTrick trick = (ViewTrick)but.BindingContext;
        trick.IsSliderVis = !trick.IsSliderVis;
    }
}