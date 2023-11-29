namespace MauiApp1;

public partial class HomePage : ContentPage
{
    private ViewTrainer _trainer = new();
    public HomePage()
	{
		InitializeComponent();
        BindingContext = _trainer;
	}
    protected override void OnAppearing()
    {
        Refresh();
    }

    private async void Refresh()
    {

        await _trainer.loadAPI(1);
        int x = _trainer.Dogs.Count;
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync($"/DogProfilePage");
    }
}