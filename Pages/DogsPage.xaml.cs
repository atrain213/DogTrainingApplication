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
        Frame frm = (Frame)sender;
        BookInfo book = new();
        if (frm.BindingContext != null)
        {
            book = frm.BindingContext as BookInfo;
        }
        var parm = new Dictionary<string, object> { { "ID", book.ID } };

        await Shell.Current.GoToAsync($"/DogProfilePage", parm);
    }

    private async void ImageCell_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/DogProfilePage");
    }
}
