using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MasterRSREM.ViewModels
{
    /// <summary>
    /// Base View Model that fires Property Changed event as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        //Base event that fires when any child property changes its values
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
