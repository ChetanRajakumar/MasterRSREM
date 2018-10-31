using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Graphics;
using Android.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;

namespace MasterRSREM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileDetails : ContentPage
    {
        public bool busy;
        public Byte[] imageByte;
        public ProfileDetails()
        {
            InitializeComponent();
            userNameLabel.Text = MasterHomePageMaster.UserName;
        }

        private void changePasswordButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new PasswordRecoveryPage());
        }

        private void changeCardDetailsButton_Clicked(object sender, EventArgs e)
        {

        }

        private void termsAndConditionButton_Clicked(object sender, EventArgs e)
        {

        }

        private void signOutButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        private async void changePicButton_Clicked(object sender, EventArgs e)
        {
            if (busy) return;
            busy = true;
            ((Button)sender).IsEnabled = false;
            try

            {
                System.IO.Stream imageStream = null;
                await Plugin.Media.CrossMedia.Current.Initialize();

                if (CrossMedia.Current.IsPickPhotoSupported)
                {
                    var photo = await CrossMedia.Current.PickPhotoAsync();
                    imageStream = photo.GetStream();
                    BinaryReader br = new BinaryReader(imageStream);
                    imageByte = br.ReadBytes((int)imageStream.Length);

                    circleImageControl.Source = ImageSource.FromStream(() =>
                    {
                        var stream = photo.GetStream();
                        photo.Dispose();
                        return stream;

                    });
                }
            }

            catch (Exception ex)
            {

            }
            ((Button)sender).IsEnabled = true;

            busy = false;
        }
    }

   
}