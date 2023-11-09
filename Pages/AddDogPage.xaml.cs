namespace MauiApp1;

public partial class AddDogPage : ContentPage
{
    public AddDogPage()
    {
        InitializeComponent();
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