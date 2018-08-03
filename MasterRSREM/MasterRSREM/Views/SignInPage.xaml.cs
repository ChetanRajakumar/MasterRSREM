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
        public SignInPage ()
		{
			InitializeComponent ();
            
             GetUserNameFromDB();

            userNameEntry.Text = customerItem.EmailID;
            
		}

        async void GetUserNameFromDB()
        {
             customerItem = await App.Database.GetItemAsync("chetan");
            
        }
       

        public void BackButtonClickedAsync()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
            

        }

        public void LoginButtonClickedAsync()
        {
            App.Current.MainPage = new NavigationPage(new MasterHomePage());


        }

        public void ForgotPasswordClickedAsync()
        {
            App.Current.MainPage = new NavigationPage(new PasswordRecoveryPage());
            
        }

        private void RememberMeSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}