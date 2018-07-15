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
	public partial class SignInPage : ContentPage
	{
		public SignInPage ()
		{
			InitializeComponent ();
            
        }

       
        public void SignInClickedAsync()
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());

        }

        public void SignUpClickedAsync()
        {
            App.Current.MainPage = new NavigationPage(new SignUpPage());

        }



    }
}