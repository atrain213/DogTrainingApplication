namespace MauiApp1;

public partial class BehaviorPage : ContentPage
{
    private ViewDogTricks _trick = new();
    public BehaviorPage()
	{
		InitializeComponent();
        BindingContext = _trick;

    }
    protected override void OnAppearing()
    {
        Refresh();
    }

    private async void Refresh()
    {

        await _trick.LoadByDogTricks(1);
        int x = _trick.Tricks.Count;
    }
}