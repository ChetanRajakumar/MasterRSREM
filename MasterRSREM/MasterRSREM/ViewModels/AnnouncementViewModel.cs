using MasterRSREM.Models;
using MasterRSREM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace MasterRSREM.ViewModels
{
    class AnnouncementViewModel : INotifyPropertyChanged
    {
        public List<AnnouncementItems> AnnouncementItems { get; set; }
        public AnnouncementViewModel(string emailId)
        {
            GetAnnouncementItems(emailId);
        }
        public async void GetAnnouncementItems(string emailId)
        {
            AnnouncementItems = await App.Database.GetAnnouncementItemsAsync(emailId);
            //AnnouncementItems = items;
            OnPropertyChanged("AnnouncementItems");
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
