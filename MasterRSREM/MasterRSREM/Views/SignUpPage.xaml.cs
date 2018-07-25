﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterRSREM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}

        public void BackButtonClickedAsync()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());

        }

        public void RegisterButtonClickedAsync()
        {
            App.Current.MainPage = new NavigationPage(new SignInPage());

        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            SecurityAnswerEntry.IsVisible = true;
        }
    }
}