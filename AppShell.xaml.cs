using MauiApp1.Pages;

namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("DogProfilePage", typeof(DogProfilePage));
		Routing.RegisterRoute("BehaviorPage", typeof(SpecificBehaviorInfoPage));
		Routing.RegisterRoute("AddDogPage", typeof(AddDogPage));
		Routing.RegisterRoute("NewSession", typeof(NewSession));
        Routing.RegisterRoute("TrainerSearch", typeof(TrainerSearch));
        Routing.RegisterRoute("AccountPage", typeof(AccountPage));
        Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));
        Routing.RegisterRoute("DataExportPage", typeof(DataExportPage));
        Routing.RegisterRoute("HomePage", typeof(HomePage));
        Routing.RegisterRoute("TrainerBioPage", typeof(TrainerBioPage));
        Routing.RegisterRoute("DetailSessions", typeof(DetailSessions));
    }
}


