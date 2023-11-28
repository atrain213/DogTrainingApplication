namespace MauiApp1;

public partial class AddDogPage : ContentPage
{
    public ViewDogEdits View { get; set; } = new();
    private Stream _source = null;
    private Stream _savesource = null;
    private string _type = string.Empty;

    public AddDogPage()
    {
        InitializeComponent();
        Refresh();
        BindingContext = View;
    }

    public async void Refresh()
    {
        await View.loadAPI(0);
    }


    private void DatePick(object sender, EventArgs e)
        {
            datePicker.IsOpen = true;
        }

    private void datePicker_Closed(object sender, EventArgs e)
    {
        dateButton.Text = datePicker.SelectedDate.ToString("MM/dd/yyyy");
    }

    private async void Submit_Button_Clicked(object sender, EventArgs e)
    {
        int photoID = 1;
        if(!string.IsNullOrEmpty(_type))
        {
            int newphotoid = View.PhotoID == 1 ?  0 : View.PhotoID;
            int typeid = _type.Contains("png") ? 1 : 2;
            DTOPicture dto = new() { ID = newphotoid, Name = View.Name + "'s Picture", type_ID = typeid };
            photoID = await WebConnect.SavePicture(dto);
            if (photoID < 1)
            { 
                photoID = 1;
            }
            else
            {
                APIPicture pic = await WebConnect.GetPicture(photoID);
                if (pic.ID > 0)
                {
                    MyBlob.UploadImage(_savesource, pic.FileName());
                }
            }
        }

        View.PhotoID = photoID;
        if (await View.saveData())
        {
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            //alert
        }
    }

    public async Task SetImageAsync(FileResult frst)
    {
        if (frst != null)
        {
            PhotoFrame.IsVisible = true;
            _type = frst.ContentType;
            _source = await frst.OpenReadAsync();
            _savesource = await frst.OpenReadAsync();
            _source.Position = 0;
            ImageSource src = ImageSource.FromStream(() => _source);
            PhotoPreview.Source = src;
        }
    }


    private async void Upload_Button_Clicked(object sender, EventArgs e)
    {
        FileResult photo = await MediaPicker.Default.PickPhotoAsync();
        if (photo != null)
        {
            await SetImageAsync(photo);
        }

    }

    private async void Take_Photo_Button_Clicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                await SetImageAsync(photo);
            }
        }

    }
}