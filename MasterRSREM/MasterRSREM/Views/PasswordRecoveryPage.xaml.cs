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
	public partial class PasswordRecoveryPage : ContentPage
	{
		public PasswordRecoveryPage ()
		{
			InitializeComponent ();
		}

        public void RecoverPasswordButtonClickedAsync()
        {
            // Fetch Security Question and Show it to user
            //Enable SecurityQuestionLabel and SecurityAnswerEntry


        }

        private void ResetPasswordButtonClickedAsync(object sender, EventArgs e)
        {
            //Form 
            //Enable ResetLinkLabel
        }
    }
}