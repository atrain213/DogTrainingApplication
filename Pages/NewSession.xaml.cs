namespace MauiApp1;

public partial class NewSession : ContentPage
{
    public NewSession()
    {
        InitializeComponent();
    }
    private void SaveTrainingSession_Clicked(object sender, EventArgs e)

    {

        // Retrieve the input data and save the training session 

        string dogName = DogNameEntry.Text;

        string trainer = TrainerEntry.Text;

        string trainingType = TrainingTypeEntry.Text;

        if (int.TryParse(DurationEntry.Text, out int duration))

        {

            // Save the training session data  

        }
    }
}