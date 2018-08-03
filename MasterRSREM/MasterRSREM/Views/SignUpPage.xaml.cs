using MasterRSREM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Diagnostics;

namespace MasterRSREM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
            BindingContext = new Customer();
        }

       

        public void BackButtonClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
           
        }

        public async void RegisterButtonClickedAsync(object sender, EventArgs e)
        {
            
            var customerDetails = (Customer)BindingContext;
            customerDetails.SecurityQuestion = picker.SelectedItem.ToString();
            customerDetails.SecurityAnswer = SecurityAnswerEntry.Text;
            await App.Database.SaveItemAsync(customerDetails);
            await Navigation.PopAsync();

            App.Current.MainPage = new NavigationPage(new SignInPage());

        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            SecurityAnswerEntry.IsVisible = true;
        }
    }
}