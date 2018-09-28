using MasterRSREM.Models;
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
        public SignInPage (bool isAdmin=false)
		{
            
            InitializeComponent ();

            if (isAdmin)
            {
                adminLabel.IsVisible = true;
            }
            else
            {
                normalUserLabel.IsVisible = true;
            }


        }


        public void BackButtonClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        public async void LoginButtonClickedAsync(object sender, EventArgs e)
        {
            try
            {
                customerItem = await App.Database.GetCustomerItemAsync(userNameEntry.Text);
                
                //GetCustomer(userNameEntry.Text);
                if(customerItem!= null)
                { 
                    if (customerItem.EmailID == userNameEntry.Text && customerItem.Password == userPasswordEntry.Text)
                    {
                        if(customerItem.Type == "Admin" )
                        {
                            App.Current.MainPage = new NavigationPage(new MasterHomePage(true, customerItem.FirstName + " " + customerItem.LastName));
                        }
                        else
                        {

                            App.Current.MainPage = new NavigationPage(new MasterHomePage(false, customerItem.FirstName + " " + customerItem.LastName));
                        }
                    }
                    else
                    {
                        errorLoginLabel.IsVisible = true;
                        errorLoginLabel.Text = "In-Correct Password, Try again";
                    }
                }
                else
                {
                    errorLoginLabel.IsVisible = true;
                    errorLoginLabel.Text = "Email-ID not registered, Please Sign-up";
                }

            }
            catch (Exception ex)
            {

                errorLoginLabel.IsVisible = true;
                errorLoginLabel.Text = ex.Message;
            }
           


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