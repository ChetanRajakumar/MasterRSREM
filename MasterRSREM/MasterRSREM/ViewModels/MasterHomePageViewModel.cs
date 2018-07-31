using MasterRSREM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MasterRSREM.ViewModels
{
    class MasterHomePageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MasterHomePageMenuItem> MenuItems { get; set; }

        public MasterHomePageViewModel()
        {
            MenuItems = new ObservableCollection<MasterHomePageMenuItem>(new[]
            {
                    new MasterHomePageMenuItem { Id = 0, Title = "Announcements" },
                    new MasterHomePageMenuItem { Id = 1, Title = "Request Maintainance" },
                    new MasterHomePageMenuItem { Id = 2, Title = "Events" },
                    new MasterHomePageMenuItem { Id = 3, Title = "Book Club House" },
                    new MasterHomePageMenuItem { Id = 4, Title = "Maintenance History" },
                    new MasterHomePageMenuItem { Id = 4, Title = "Contact Us" },
                    new MasterHomePageMenuItem { Id = 4, Title = "Profile Details" },
                    new MasterHomePageMenuItem { Id = 4, Title = "Sign Out" }
                });
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
