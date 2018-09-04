using MasterRSREM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasterRSREM.Data
{
   
    public class RSREMCustomerDB
    {
        readonly SQLiteAsyncConnection database;

        public RSREMCustomerDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Customer>().Wait();
            database.CreateTableAsync<AnnouncementItems>().Wait();
            database.CreateTableAsync<Categories>().Wait();
        }

        public Task<List<Customer>> GetCustomerItemsAsync()
        {
            return database.Table<Customer>().ToListAsync();
        }

        
        public Task<Customer> GetCustomerItemAsync(string emailID)
        {
            return database.Table<Customer>().Where(i => i.EmailID == emailID).FirstOrDefaultAsync();
        }


        public Task<int> SaveCustomerItemAsync(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.EmailID))
            {
                return database.UpdateAsync(customer);
            }
            else
            {
                return database.InsertAsync(customer);
            }
        }

        public Task<int> DeleteCustomerItemAsync(Customer customer)
        {
            return database.DeleteAsync(customer);
        }

        public Task<List<AnnouncementItems>> GetAnnouncementItemsAsync()
        {
            return database.Table<AnnouncementItems>().ToListAsync();
        }


        public Task<AnnouncementItems> GetAnnouncementItemsAsync(string title)
        {
            return database.Table<AnnouncementItems>().Where(i => i.Title == title).FirstOrDefaultAsync();
        }


        public Task<int> SaveAnnouncementItemAsync(AnnouncementItems announcement)
        {
            if (string.IsNullOrEmpty(announcement.Title))
            {
                return database.UpdateAsync(announcement);
            }
            else
            {
                return database.InsertAsync(announcement);
            }
        }

        public Task<int> DeleteAnnouncementItemAsync(AnnouncementItems announcement)
        {
            return database.DeleteAsync(announcement);
        }

        public Task<List<Categories>> GetCategoryItemsAsync()
        {
            return database.Table<Categories>().ToListAsync();
        }


        public Task<Categories> GetCategoryItemsAsync(string categoryItem)
        {
            return database.Table<Categories>().Where(i => i.Category == categoryItem).FirstOrDefaultAsync();
        }


        public Task<int> SaveCategoryItemAsync(Categories categoryItem)
        {
            if (string.IsNullOrEmpty(categoryItem.Category))
            {
                return database.UpdateAsync(categoryItem);
            }
            else
            {
                return database.InsertAsync(categoryItem);
            }
        }

        public Task<int> DeleteCategoryItemAsync(Categories categoryItem)
        {
            return database.DeleteAsync(categoryItem);
        }
    }
}
