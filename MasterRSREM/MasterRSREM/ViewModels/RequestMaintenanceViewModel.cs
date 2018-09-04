using MasterRSREM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MasterRSREM.ViewModels
{
    public class RequestMaintenanceViewModel : INotifyPropertyChanged
    {
        public List<Categories> CategoryItems { get; set; }
        public RequestMaintenanceViewModel()
        {
            GetCategoryItems();
        }
        public async void GetCategoryItems()
        {
            CategoryItems = await App.Database.GetCategoryItemsAsync();
            //AnnouncementItems = items;
            OnPropertyChanged("CategoryItems");
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
