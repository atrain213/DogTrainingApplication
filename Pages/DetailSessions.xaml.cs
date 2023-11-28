namespace MauiApp1;

public partial class DetailSessions : ContentPage
{
	public DetailSessions()
	{
		InitializeComponent();
	}

	private void SaveButton_Clicked(object sender, EventArgs e)
	{
		string CurrentSessionNotes = CurrentSessionNotesEntry.Text;
		string NextSessionNotes = NextSessionNotesEntry.Text;
		string CustomNotes = CustomNotesEntry.Text;
	}
}