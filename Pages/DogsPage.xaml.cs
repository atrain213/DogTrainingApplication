namespace MauiApp1;

//using Syncfusion.ListView.XForms;
//using Syncfusion.Maui.ListView;

public partial class DogsPage : ContentPage
{
    private ViewTrainer _trainer = new();
    public DogsPage()
    {
       

        InitializeComponent();
        BindingContext = _trainer;
        Refresh();
        //SfListView listView = new SfListView();
        //this.Content = listView;

    }

    private async void Refresh()
    {
        await _trainer.loadAPI(1);
        int x = _trainer.Dogs.Count;
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

    //private async void ImageCell_Tapped(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync($"/DogProfilePage");
    //}
}
