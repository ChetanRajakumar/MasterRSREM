﻿using MasterRSREM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterRSREM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage
	{
        Customer customerItem = new Customer();
        public SignInPage ()
		{
			InitializeComponent ();
            
            
		}

        
        public void BackButtonClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
            

        }

        public void LoginButtonClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MasterHomePage());

            //GetCustomer(userNameEntry.Text);
            //if (customerItem.EmailID != "" && customerItem.EmailID == userNameEntry.Text)
            //{
            //    if ((customerItem.Password == userPasswordEntry.Text))
            //    {
            //        App.Current.MainPage = new NavigationPage(new MasterHomePage());
            //    }
            //    else
            //    {
            //        errorLoginLabel.IsVisible = true;
            //        errorLoginLabel.Text = "In-Correct Password, Try again";
            //    }
            //}
            //else
            //{
            //    errorLoginLabel.IsVisible = true;
            //    errorLoginLabel.Text = "Email-ID not registered, Please Sign-up";
            //}


        }

        public async void GetCustomer(string emailId)
        {
            customerItem = await App.Database.GetItemAsync(emailId);
        }

        public void ForgotPasswordClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new PasswordRecoveryPage());
            
        }

        private void RememberMeSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}