namespace MauiApp1;

public partial class AddDogPage : ContentPage
{
    public ViewBreeds View { get; set; } = new();

    public AddDogPage()
    {
        InitializeComponent();
        Refresh();
        BindingContext = View;
    }

    public async void Refresh()
    {
        await View.loadAPI();
    }


    private void DatePick(object sender, EventArgs e)
        {
            datePicker.IsOpen = true;
        }

    private void datePicker_Closed(object sender, EventArgs e)
    {
        dateButton.Text = datePicker.SelectedDate.ToString("MM/dd/yyyy");
    }


}