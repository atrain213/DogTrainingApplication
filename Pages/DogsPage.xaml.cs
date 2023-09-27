namespace MauiApp1;

//using Syncfusion.ListView.XForms;
//using Syncfusion.Maui.ListView;

public partial class DogsPage : ContentPage
{
    public DogsPage()
    {
       

        InitializeComponent();
        //SfListView listView = new SfListView();
        //this.Content = listView;

    }


    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync($"/DogProfilePage");
    }

    private async void ImageCell_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/DogProfilePage");
    }
}
