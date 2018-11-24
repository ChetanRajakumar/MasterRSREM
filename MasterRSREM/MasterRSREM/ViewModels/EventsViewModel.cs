using MasterRSREM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MasterRSREM.ViewModels
{
    class EventsViewModel : INotifyPropertyChanged
    {
        public List<Events> Events { get; set; }
        public EventsViewModel(string emailId)
        {
            GetEventsRequestItems(emailId);
        }
        public async void GetEventsRequestItems(string emailId)
        {
            Events = await App.Database.GetEventsRequestItemsAsync();
            //AnnouncementItems = items;
            OnPropertyChanged("Events");
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
