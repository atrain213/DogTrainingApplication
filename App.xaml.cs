namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
		Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cXmVCf1NpR2dGfV5yd0VAalxZTnVYUj0eQnxTdEZjUH1bcXBWRGNYUkxzXw==");

		InitializeComponent();

        Application.Current.UserAppTheme = AppTheme.Light;
        MainPage = new AppShell();
	}
}
