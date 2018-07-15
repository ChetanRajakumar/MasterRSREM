﻿using System;
using Xamarin.Forms;
using MasterRSREM.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MasterRSREM
{
	public partial class App : Application
	{
		
		public App ()
		{
			InitializeComponent();


			MainPage = new SignInPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}