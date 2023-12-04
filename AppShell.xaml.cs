using MauiApp1.Pages;

namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("DogProfilePage", typeof(DogProfilePage));
		Routing.RegisterRoute("SpecificBehaviorPage", typeof(SpecificBehaviorInfoPage));
        Routing.RegisterRoute("BehaviorPage", typeof(BehaviorPage));
        Routing.RegisterRoute("AddDogPage", typeof(AddDogPage));
		Routing.RegisterRoute("NewSession", typeof(NewSession));
        Routing.RegisterRoute("TrainerSearch", typeof(TrainerSearch));
        Routing.RegisterRoute("AccountPage", typeof(AccountPage));
        Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));
        Routing.RegisterRoute("DataExportPage", typeof(DataExportPage));
        Routing.RegisterRoute("HomePage", typeof(HomePage));
        Routing.RegisterRoute("TrainerBioPage", typeof(TrainerBioPage));
        Routing.RegisterRoute("DetailSessions", typeof(DetailSessions));
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("TrainingPage", typeof(TrainingPage));
        Routing.RegisterRoute("StartSessionPage",typeof(StartSessionPage));
        Routing.RegisterRoute("SessionPage", typeof(SessionPage));
        Routing.RegisterRoute("ChangeTrickPage", typeof(ChangeTrickPage));
        Routing.RegisterRoute("ReportPage", typeof(ReportPage));
        Routing.RegisterRoute("SessionSummaryPage", typeof(SessionSummaryPage));
        Routing.RegisterRoute("CalendarPage", typeof(CalenderPage));
        BindingContext = MyAccount.Contact;
    }
}


