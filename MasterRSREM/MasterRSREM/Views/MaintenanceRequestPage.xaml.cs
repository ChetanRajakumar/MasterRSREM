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
    public partial class MaintenanceRequestPage : ContentPage
    {
        public MaintenanceRequestPage()
        {
            InitializeComponent();
        }

        private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}