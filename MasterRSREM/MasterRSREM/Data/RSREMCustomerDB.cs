using MasterRSREM.Models;
using MasterRSREM.RestClient;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasterRSREM.Data
{

    public class RSREMCustomerDB
    {
        CustomerRestClient<Customer> customerRestClient = new CustomerRestClient<Customer>();
        AnnouncementRestClient<AnnouncementItems> announcementItemsRestClient = new AnnouncementRestClient<AnnouncementItems>();
        CategoriesRestClient<Categories> categoriesRestClient = new CategoriesRestClient<Categories>();
        MaintainenceRequestRestClient<MaintainenceRequestEntities> maintainenceRequestRestClient = new MaintainenceRequestRestClient<MaintainenceRequestEntities>();

        Customer customerItem = new Customer();
        AnnouncementItems announcementItem = new AnnouncementItems();
        Categories categorieItem = new Categories();
        MaintainenceRequestEntities maintainenceRequestItem = new MaintainenceRequestEntities();

        public static string CustomerEmailID { get; set; }

        public RSREMCustomerDB()
        { 

        }

       
        public async Task<Customer> GetCustomerItemAsync(string emailID)
        {
            CustomerEmailID = emailID;
            customerItem = await customerRestClient.GetAsync(emailID);
            return customerItem;
        }


        public async Task<bool> SaveCustomerItemAsync(Customer customer)
        {
            bool success = await customerRestClient.PostAsync(customer);
            return success;
        }

        public async Task<bool> DeleteCustomerItemAsync(string emailID)
        {
            bool success = await customerRestClient.DeleteAsync(emailID);
            return success;
        }

        public async Task<List<AnnouncementItems>> GetAnnouncementItemsAsync()
        {
            List<AnnouncementItems> announcementItems = new List<AnnouncementItems>();
            announcementItems = await announcementItemsRestClient.GetAsync();
            return announcementItems;
        }


        public async Task<List<AnnouncementItems>> GetAnnouncementItemsAsync(string emailId)
        {
            List<AnnouncementItems> announcementItems = new List<AnnouncementItems>();
            announcementItems = await announcementItemsRestClient.GetAsync(emailId);
            return announcementItems;
        }


        public async Task<bool> SaveAnnouncementItemAsync(AnnouncementItems announcement)
        {
            bool success = await announcementItemsRestClient.PostAsync(announcement);
            return success;
           
        }

        public async Task<bool> DeleteAnnouncementItemAsync(string title)
        {
            bool success = await customerRestClient.DeleteAsync(title);
            return success;
        }

        public async Task<List<Categories>> GetCategoryItemsAsync()
        {
            List<Categories> categoryItems = new List<Categories>();
            categoryItems = await categoriesRestClient.GetAsync();
            return categoryItems;
        }


        public async Task<Categories> GetCategoryItemsAsync(string category)
        {
            categorieItem = await categoriesRestClient.GetAsync(category);
            return categorieItem;
        }


        public async Task<bool> SaveCategoryItemAsync(Categories category)
        {
            bool success = await categoriesRestClient.PostAsync(category);
            return success;

        }

        public async Task<bool> DeleteCategoryItemAsync(string category)
        {
            bool success = await categoriesRestClient.DeleteAsync(category);
            return success;
        }

        public async Task<List<MaintainenceRequestEntities>> GetMaintainenceRequestItemsAsync()
        {
            List<MaintainenceRequestEntities> maintainenceRequestEntities = new List<MaintainenceRequestEntities>();
            maintainenceRequestEntities = await maintainenceRequestRestClient.GetAsync();
            return maintainenceRequestEntities;
        }

        public async Task<List<MaintainenceRequestEntities>> GetMaintainenceRequestItemsAsync(string emailID)
        {
            List<MaintainenceRequestEntities> maintainenceRequestEntities = new List<MaintainenceRequestEntities>();
            maintainenceRequestEntities = await maintainenceRequestRestClient.GetAsync(emailID);
            return maintainenceRequestEntities;
        }


        public async Task<bool> SaveMaintainenceRequestItemAsync(MaintainenceRequestEntities maintainenceRequestItem)
        {
            bool success = await maintainenceRequestRestClient.PostAsync(maintainenceRequestItem);
            return success;
        }

        public async Task<bool> DeleteMaintainenceRequestAsync(string emailID)
        {
            bool success = await maintainenceRequestRestClient.DeleteAsync(emailID);
            return success;
        }

    }
}
