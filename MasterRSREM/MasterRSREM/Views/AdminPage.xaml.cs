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
	public partial class AdminPage : ContentPage
	{
		public AdminPage ()
		{
			InitializeComponent ();
            BindingContext = new AnnouncementItems();
        }

        public async void AddAnnouncementButtonClickedAsync(object sender, EventArgs e)
        {

            var announcementsDetails = (AnnouncementItems)BindingContext;
            announcementsDetails.Title = AnnouncementsTitle.Text;
            announcementsDetails.Description = AnnouncementsDescription.Text;
            await App.Database.SaveAnnouncementItemAsync(announcementsDetails);
            await Navigation.PopAsync();
        }

    }
}