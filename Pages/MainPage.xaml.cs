﻿namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public ViewDogEdits View { get; set; } = new();

	public MainPage()
	{
		InitializeComponent();
		Refresh();
		BindingContext = View;
	}

public async void Refresh()
	{
		await View.loadAPI(0);
	}	
}


