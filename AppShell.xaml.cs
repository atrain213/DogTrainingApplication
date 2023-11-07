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
    }
}


