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
        }

        public Task<List<Customer>> GetItemsAsync()
        {
            return database.Table<Customer>().ToListAsync();
        }

        
        public Task<Customer> GetItemAsync(string emailID)
        {
            return database.Table<Customer>().Where(i => i.EmailID == emailID).FirstOrDefaultAsync();
        }


        public Task<int> SaveItemAsync(Customer customer)
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

        public Task<int> DeleteItemAsync(Customer customer)
        {
            return database.DeleteAsync(customer);
        }
    }
}
