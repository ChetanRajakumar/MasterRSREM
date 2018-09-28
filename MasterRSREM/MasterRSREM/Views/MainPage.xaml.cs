﻿using MasterRSREM.Models;
using MasterRSREM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterRSREM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            
        }

       
        public void SignInClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SignInPage());

        }

        public void SignUpClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SignUpPage());

        }

        public void AdminLoginClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SignInPage());

        }

        


    }
}