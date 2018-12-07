using MasterRSREM.Models;
using MasterRSREM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterRSREM.ViewModels
{
    public class ContactUsViewModel : INotifyPropertyChanged
    {
        public ImageSource CircleImageSource { get; set; }
        public async void ContactUsViewModelGetProfilePic(string emailId)
        {
            CircleImageSource = await GetProfilePic(emailId);
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


        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
