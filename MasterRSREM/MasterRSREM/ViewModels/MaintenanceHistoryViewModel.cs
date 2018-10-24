using MasterRSREM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MasterRSREM.ViewModels
{
    class MaintenanceHistoryViewModel : INotifyPropertyChanged
    {
        public List<MaintainenceRequestEntities> MaintainenceRequestEntities { get; set; }
        public MaintenanceHistoryViewModel(string emailId)
        {
            GetMaintainenceRequestItems(emailId);
        }
        public async void GetMaintainenceRequestItems(string emailId)
        {
            MaintainenceRequestEntities = await App.Database.GetMaintainenceRequestItemsAsync(emailId);
            //AnnouncementItems = items;
            OnPropertyChanged("MaintainenceRequestEntities");
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
