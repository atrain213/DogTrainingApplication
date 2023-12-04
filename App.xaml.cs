namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
		Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cXmVCf1FpTXxbf1xzZFRHal1TTnddUiweQnxTdEZiWH9WcXNXQmFVV0x+WA==");

		InitializeComponent();
		if (Application.Current != null)
		{
			Application.Current.UserAppTheme = AppTheme.Light;
		}
        MainPage = new AppShell();
		Setup();
	}
	public async void Setup()
	{
		await MyAccount.LoadContantAsync(3);
	}
}
