using MasterRSREM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MasterRSREM.Models;

namespace MasterRSREM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnnouncementsPage : ContentPage
	{
        public AnnouncementsPage ()
		{
			InitializeComponent ();
            BindingContext = new AnnouncementViewModel();
            
        }
        
    }
}