using Android.Media;
using MasterRSREM.ViewModels;
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
        MediaPlayer mediaPlayer = new MediaPlayer();
        public MaintenanceRequestPage()
        {
            InitializeComponent();
            BindingContext = new RequestMaintenanceViewModel();
        }

        private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void RecordButton_Clicked(object sender, EventArgs e)
        {
            mediaPlayer.Start();
        }

        private void PauseButton_Clicked(object sender, EventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void StopButton_Clicked(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
        }
    }
}