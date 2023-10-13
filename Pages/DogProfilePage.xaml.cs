
namespace MauiApp1;

[QueryProperty(nameof(ID), "ID")]
public partial class DogProfilePage : ContentPage
{
    public BehaviorViewModel View { get; set; } = new();

    private int _id;
    public int ID
    {
        get { return _id; }
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged();
                Refresh();
            }
        }
    }
    public DogProfilePage()
	{
		InitializeComponent();
        BindingContext = View;
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

    private async void Refresh()
    {
        await View.Refresh(ID);
    }
}