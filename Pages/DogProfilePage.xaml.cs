namespace MauiApp1;

public partial class DogProfilePage : ContentPage
{
	public DogProfilePage()
	{
		InitializeComponent();
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        Shell.SetTabBarIsVisible(Application.Current, false);
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync($"/BehaviorPage");
    }

    private async void ImageCell_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/DogProfilePage");
    }
}