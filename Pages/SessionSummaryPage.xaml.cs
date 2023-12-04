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
        Button button  = (Button)sender;
        if (button != null)
        {
            button.IsEnabled = false;
            int retval = await _session.PostDTO();
            if (retval > 0)
            {
                await Shell.Current.GoToAsync($"../../../");
                
            }
            button.IsEnabled = true;
            //Else Error
        }
        
    }

    private void SetLevel_Clicked(object sender, EventArgs e)
    {
        ImageButton but = (ImageButton)sender;
        ViewTrick trick = (ViewTrick)but.BindingContext;
        trick.IsSliderVis = !trick.IsSliderVis;
    }
}