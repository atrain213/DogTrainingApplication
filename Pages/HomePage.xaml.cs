namespace MauiApp1;

public partial class HomePage : ContentPage
{
    private ViewOwner _owner = new();
    public HomePage()
	{
		InitializeComponent();
        BindingContext = _owner;
	}
    protected override async void OnAppearing()
    {
        await Task.Delay(100);
        Refresh();
    }

    private async void Refresh()
    {
        await _owner.loadAPI(MyAccount.Contact.OwnerID);
        Greeting.Text = "Welcome, " + MyAccount.Contact.FName;
        int x = _owner.Dogs.Count;
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Frame frm = (Frame)sender;
        if (frm.BindingContext != null)
        {
            ViewDog? vd = frm.BindingContext as ViewDog;
            if (vd != null)
            {
                var parm = new Dictionary<string, object> { { "ID", vd.ID } };

                await Shell.Current.GoToAsync($"/DogProfilePage", parm);
            }
        }
    }
}