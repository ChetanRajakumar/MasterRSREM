using System;
using Xamarin.Forms;
using MasterRSREM.Views;
using Xamarin.Forms.Xaml;
using MasterRSREM.Data;
using System.IO;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MasterRSREM
{
	public partial class App : Application
	{
        static RSREMCustomerDB customerDatabase;
		public App ()
		{
			InitializeComponent();


			MainPage = new MainPage();
		}
        
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public static RSREMCustomerDB Database
        {
            get
            {
                
                if (customerDatabase == null)
                {
                    customerDatabase = new RSREMCustomerDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "CustomerSQLite.db3"));
                }
                return customerDatabase;
            }
        }
    }
}
