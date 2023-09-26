namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("DogProfilePage", typeof(DogProfilePage));
		Routing.RegisterRoute("TrainerSearch", typeof(TrainerSearch));
		Routing.RegisterRoute("AccountPage", typeof(AccountPage));
		Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));
        Routing.RegisterRoute("DataExportPage", typeof(DataExportPage));
    }
}


