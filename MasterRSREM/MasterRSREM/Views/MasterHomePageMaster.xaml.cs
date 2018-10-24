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
        public static string UserName { get; set; }

        public static string LoggedInEmailID { get; set; }

        public MasterHomePageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterHomePageViewModel(isAdmin);
            ListView = MenuItemsListView;
            userNameLabel.Text = UserName;

        }
       
        private void SignOutClickedEvent(object sender, EventArgs e)
        {
           App.Current.MainPage = new NavigationPage(new MainPage());
            
        }
    }
}