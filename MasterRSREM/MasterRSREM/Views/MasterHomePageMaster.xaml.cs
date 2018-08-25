using MasterRSREM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterRSREM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterHomePageMaster : ContentPage
    {
        public ListView ListView;
        public static bool isAdmin;

        public MasterHomePageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterHomePageViewModel(isAdmin);
            ListView = MenuItemsListView;


        }
       
        private void MenuItemsClickedEvent(object sender, EventArgs e)
        {
            Button menuButton = (Button)sender;
            if (menuButton.Text == "Sign Out" )
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            //switch (menuButton.Text)
            //{
            //    case "Announcements":
            //        Navigation.PushAsync(new AnnouncementsPage());
            //        //App.Current.MainPage = new NavigationPage(new AnnouncementsPage());
            //        break;
            //    case "Request Maintainance":
            //        App.Current.MainPage = new NavigationPage(new MaintenanceRequestPage());
            //        break;
            //    case "Events":
            //        App.Current.MainPage = new NavigationPage(new EventsPage());
            //        break;
            //    case "Book Club House":
            //        App.Current.MainPage = new NavigationPage(new BookClubHousePage());
            //        break;
            //    case "Maintenance History":
            //        App.Current.MainPage = new NavigationPage(new MaintenanceHistoryPage());
            //        break;
            //    case "Contact Us":
            //        App.Current.MainPage = new NavigationPage(new ContactUs());
            //        break;
            //    case "Profile Details":
            //        App.Current.MainPage = new NavigationPage(new ProfileDetails());
            //        break;
            //    case "Sign Out":
            //        App.Current.MainPage = new NavigationPage(new MainPage());
            //        break;
            //    default:
            //        App.Current.MainPage = new NavigationPage(new MainPage());
            //        break;
            //}

        }
    }
}