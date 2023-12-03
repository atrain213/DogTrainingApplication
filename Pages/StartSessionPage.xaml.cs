
using Microsoft.Maui.Controls;

namespace MauiApp1.Pages;

[QueryProperty(nameof(Item), "Item")]

public partial class StartSessionPage : ContentPage
{
    public ViewSession View { get; set; } = MyAccount.Session;

    private APIData item = new();
    public APIData Item
    {
        get => item;
        set
        {
            item = value;
            Refresh();
            OnPropertyChanged();
        }
    }


    public StartSessionPage()
	{
		InitializeComponent();
        BindingContext = View;
	}
    protected override void OnAppearing()
    {
        Refresh();
    }

    private async void Refresh()
    {
        switch (item.Name)
        {
            case "Dog":
                await View.LoadAPIbyDog(item.ID);
                break;
            case "Trainer":
                await View.LoadAPIbyTrainer(item.ID);
                break;
            case "Owner":
                await View.LoadAPIbyOwner(item.ID);
                break;
            default:
                if(MyAccount.Contact.IsTrainer)
                {
                    await View.LoadAPIbyTrainer(MyAccount.Contact.TrainerID);
                }
                else if(MyAccount.Contact.IsOwner)
                {
                    await View.LoadAPIbyOwner(MyAccount.Contact.OwnerID);
                }
                break;
        }
    }

    private async void StartTraining_Tapped(object sender, TappedEventArgs e)
    {
        View.SelectNone();
        if(listView.SelectedItems != null)
        {
            if(listView.SelectedItems.Count > 0)
            {
                foreach (var item in listView.SelectedItems)
                {
                    ViewTrick trick = (ViewTrick)item;
                    trick.Selected = true;
                }
                View.SetTricks();
                View.StartTime = DateTime.Now;
                await Shell.Current.GoToAsync($"/SessionPage");
            }
            else
            {
                await DisplayAlert("Start Error", "Please select a behavior before beginning.","OK");
            }

        }

        
    }


    private void SelectAll_Pressed(object sender, EventArgs e)
    {
        if (listView.SelectedItems != null)
        {
            listView.SelectedItems.Clear();
            foreach (var item in View.Tricks)
            {
                listView.SelectedItems.Add(item);
            }
        }
    }

    private void SelectNone_Pressed(object sender, EventArgs e)
    {
        if (listView.SelectedItems != null)
        {
            listView.SelectedItems.Clear();
        }
    }
}