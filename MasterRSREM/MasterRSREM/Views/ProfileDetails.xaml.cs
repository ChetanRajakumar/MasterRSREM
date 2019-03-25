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
using MasterRSREM.Models;

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
            currentPasswordEntry.IsVisible = false;
            newPasswordEntry.IsVisible = false;
            wrongPasswordLabel.IsVisible = false;
            userNameLabel.Text = MasterHomePageMaster.UserName;
            emailIdLabel.Text = MasterHomePageMaster.LoggedInEmailID;
            GetUserProfilePic(MasterHomePageMaster.LoggedInEmailID);
        }

        public async void GetUserProfilePic(string emailId)
        {
            circleImageControl.Source = await GetProfilePic(emailId);
        }

        private void changePasswordButton_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new NavigationPage(new PasswordRecoveryPage());
            currentPasswordEntry.IsVisible = true;
            newPasswordEntry.IsVisible = true;
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

        private async void updateProfileButton_Clicked(object sender, EventArgs e)
        {
            Customer customerItem = new Customer();
            customerItem = await App.Database.GetCustomerItemAsync(MasterHomePageMaster.LoggedInEmailID);

            if (customerItem != null)
            {
                if (!string.IsNullOrEmpty(newPasswordEntry.Text ) && !string.IsNullOrEmpty(currentPasswordEntry.Text))
                {
                    if (currentPasswordEntry.Text == customerItem.Password)
                    {
                        customerItem.Password = newPasswordEntry.Text;
                    }
                    else
                    {
                        wrongPasswordLabel.IsVisible = true;
                    }
                }
                if (imageByte != null)
                {
                    customerItem.ProfilePic = imageByte;
                }
                await App.Database.SaveCustomerItemAsync(customerItem);

            }
        }

        private async void takePicButton_Clicked(object sender, EventArgs e)
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
                    TakePictureAsync(circleImageControl);
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

        public async Task<ImageSource> GetProfilePic(string emailId)
        {
            ImageSource imageSource = null;
            Customer customerItem = new Customer();
            customerItem = await App.Database.GetCustomerItemAsync(emailId);
            if (customerItem != null)
            {
                if (customerItem.ProfilePic != null)
                {
                    imageSource = ImageSource.FromStream(() => new MemoryStream(customerItem.ProfilePic));
                    OnPropertyChanged("CircleImageSource");
                }

            }
            return imageSource;
        }

        private async void TakePictureAsync(Xamarin.Forms.Image photoImage)
        {
            System.IO.Stream imageStream = null;
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                Name = "test.jpg",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 100,
                PhotoSize = PhotoSize.Large,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });

            if (file == null) return;

            await DisplayAlert("File Location", file.Path, "OK");

            imageStream = file.GetStream();
            BinaryReader br = new BinaryReader(imageStream);
            imageByte = br.ReadBytes((int)imageStream.Length);

            photoImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;

            });
        }
    }

   
}