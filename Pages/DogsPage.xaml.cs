namespace MauiApp1;

public partial class DogsPage : ContentPage
{
    public DogsPage()
    {
       

        InitializeComponent();
        
    }

    int count = 0;
    private void OnCounterClicked(object sender, EventArgs e)
    {
        
        count++;

        if (count == 1)
        {
            NewDog.Text = $"Added {count} dog";
        }
        else
        {
            NewDog.Text = $"Added {count} dogs";
        }
        SemanticScreenReader.Announce(NewDog.Text);
    }
}
	