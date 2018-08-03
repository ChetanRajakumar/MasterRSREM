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

        public MasterHomePageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterHomePageViewModel();
            ListView = MenuItemsListView;


        }

        private void MenuItemsClickedEvent(object sender, EventArgs e)
        {
            Button menuButton = (Button)sender;
            if(menuButton.Text == "Sign Out")
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
            }

        }
    }
}