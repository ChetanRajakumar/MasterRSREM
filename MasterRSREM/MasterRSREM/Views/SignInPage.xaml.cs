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
		public SignInPage ()
		{
			InitializeComponent ();
		}

        //async void Handle_Clicked(object sender, System.EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new MainPage());
        //}

        public void BackButtonClickedAsync()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
            

        }

        public void LoginButtonClickedAsync()
        {
            App.Current.MainPage = new NavigationPage(new HomePage());


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