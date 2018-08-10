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
    class MasterHomePageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MasterHomePageMenuItem> MenuItems { get; set; }

        public MasterHomePageViewModel()
        {
            MenuItems = new ObservableCollection<MasterHomePageMenuItem>(new[]
            {
                    new MasterHomePageMenuItem { Id = 0, Title = "Announcements", TargetType= typeof(AnnouncementsPage)},
                    new MasterHomePageMenuItem { Id = 1, Title = "Request Maintainance",TargetType= typeof(MaintenanceRequestPage) },
                    new MasterHomePageMenuItem { Id = 2, Title = "Events", TargetType= typeof(EventsPage) },
                    new MasterHomePageMenuItem { Id = 3, Title = "Book Club House", TargetType= typeof(BookClubHousePage) },
                    new MasterHomePageMenuItem { Id = 4, Title = "Maintenance History", TargetType= typeof(MaintenanceHistoryPage) },
                    new MasterHomePageMenuItem { Id = 5, Title = "Contact Us" , TargetType= typeof(ContactUs)},
                    new MasterHomePageMenuItem { Id = 6, Title = "Profile Details", TargetType= typeof(ProfileDetails) },
                    new MasterHomePageMenuItem { Id = 7, Title = "Sign Out" }
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
