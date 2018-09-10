using Android.Media;
using MasterRSREM.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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
        bool busy;
        MediaPlayer mediaPlayer = new MediaPlayer();
        public MaintenanceRequestPage()
        {
            InitializeComponent();
            CameraButton.Clicked += CameraButton_Clicked;
            BindingContext = new RequestMaintenanceViewModel();
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            if (busy) return;
            busy = true;
            ((Button)sender).IsEnabled = false;
            try

            {
                await Plugin.Media.CrossMedia.Current.Initialize();

                var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Camera);


                if (cameraStatus == PermissionStatus.Granted)
                {
                    if (PhotoImage1.Source == null)
                    {
                        TakePictureAsync(PhotoImage1);

                    }
                    else if (PhotoImage2.Source == null)
                    {
                        TakePictureAsync(PhotoImage2);
                    }
                    else if (PhotoImage3.Source == null)
                    {
                        TakePictureAsync(PhotoImage3);
                    }
                    else if (PhotoImage4.Source == null)
                    {
                        TakePictureAsync(PhotoImage4);
                    }
                    else if (PhotoImage5.Source == null)
                    {
                        TakePictureAsync(PhotoImage5);
                    }
                    else
                    {
                        await DisplayAlert("Take Photo Denied", "Can not upload more than 5 photos", "OK");
                    }
                }

                else if (cameraStatus == PermissionStatus.Unknown)
                {

                    await DisplayAlert("Camera Unknown", "Can not continue, Please check if your camer permissions is ON and try again.", "OK");

                }

                else if (cameraStatus == PermissionStatus.Denied)
                {

                    await DisplayAlert("Camera Denied", "Can not continue, try again.", "OK");

                }

            }

            catch (Exception ex)
            {

            }
            ((Button)sender).IsEnabled = true;

            busy = false;
        }

        private async void TakePictureAsync(Xamarin.Forms.Image photoImage)
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 100,
                PhotoSize = PhotoSize.Large,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });

            if (file == null) return;

            await DisplayAlert("File Location", file.Path, "OK");


            photoImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;

            });
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

        private void SendRequest_ButtonClicked(object sender, EventArgs e)
        {
        }
    }
}