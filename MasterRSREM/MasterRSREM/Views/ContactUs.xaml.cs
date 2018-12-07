using MasterRSREM.Models;
using MasterRSREM.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterRSREM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactUs : ContentPage
	{
		public ContactUs ()
		{
			InitializeComponent ();
            contactUsMessageLabel.Text = " Hello  " + MasterHomePageMaster.UserName;
            callMessageLabel.Text = " +91 - 9663413720 or +91 - 1234567890";
            emailMessageLabel.Text = "chetan.sudeep2004@gmail.com or      bal.rajakumar@gmail.com";
            ContactUsViewModel contactUsViewModel  = new ContactUsViewModel();
            contactUsViewModel.ContactUsViewModelGetProfilePic(MasterHomePageMaster.LoggedInEmailID);
            BindingContext = contactUsViewModel;
        }

        private void CallButton_Clicked(object sender, EventArgs e)
        {
            //Open Dail pad and enter allow user to call customer care number
        }

        private void EmailButton_Clicked(object sender, EventArgs e)
        {
            //Open outlook and send email to customer support team
        }

        
    }
}