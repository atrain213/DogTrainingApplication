
namespace MauiApp1;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{

		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        Refresh();
    }

    private async void Refresh()
	{
		Contacts.ItemsSource = await WebConnect.ContactsAsync();
	}

    private async void Select_Clicked(object sender, EventArgs e)
    {
        if (Contacts.SelectedItem != null)
        {
            APIData api = (APIData) Contacts.SelectedItem;
            await MyAccount.LoadContantAsync(api.ID);
            await Shell.Current.GoToAsync($"..");
        }
    }
}