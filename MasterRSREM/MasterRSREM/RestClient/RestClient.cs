using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MasterRSREM.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class CustomerRestClient<T>
    {
        private const string WebServiceUrl = "http://192.168.0.24:8080/api/Customers/";

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }
        
       
        public async Task<T> GetAsync(string emailId)
        {
            emailId = "?emailId=" + emailId;
            string url = WebServiceUrl + emailId;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var taskModels = JsonConvert.DeserializeObject<T>(json);
            return taskModels;
            
        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        
        public async Task<bool> DeleteAsync(string emailId)
        {
            emailId = "?emailId=" + emailId;
            string url = WebServiceUrl + emailId;
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }

    public class AnnouncementRestClient<T>
    {
        private const string WebServiceUrl = "http://192.168.0.24:8080/api/AnnouncementItems/";

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }


        public async Task<List<T>> GetAsync(string email)
        {
            email = "?emailID=" + email;
            string url = WebServiceUrl + email;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
            return taskModels;

        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string title)
        {
            title = "?title=" + title;
            string url = WebServiceUrl + title;
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }

    public class CategoriesRestClient<T>
    {
        private const string WebServiceUrl = "http://192.168.0.24:8080/api/Categories/";

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }


        public async Task<T> GetAsync(string category)
        {
            category = "?category=" + category;
            string url = WebServiceUrl + category;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var taskModels = JsonConvert.DeserializeObject<T>(json);
            return taskModels;

        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string category)
        {
            category = "?category=" + category;
            string url = WebServiceUrl + category;
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }

    public class MaintainenceRequestRestClient<T>
    {
        private const string WebServiceUrl = "http://192.168.0.24:8080/api/MaintainenceRequestEntities/";

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }


        public async Task<List<T>> GetAsync(string emailId)
        {
            emailId = "?emailId=" + emailId;
            string url = WebServiceUrl + emailId;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
            return taskModels;

        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string emailId)
        {
            emailId = "?emailId=" + emailId;
            string url = WebServiceUrl + emailId;
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }

    public class EventsClient<T>
    {
        private const string WebServiceUrl = "http://192.168.0.24:8080/api/Events/";

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }


        public async Task<List<T>> GetAsync(string title)
        {
            title = "?title=" + title;
            string url = WebServiceUrl + title;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
            return taskModels;

        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string urlId = "?id=" + Convert.ToString(id);
            string url = WebServiceUrl + urlId;
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string title)
        {
            title = "?title=" + title;
            string url = WebServiceUrl + title;
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }

    public class ClubHouseClient<T>
    {
        private const string WebServiceUrl = "http://192.168.0.24:8080/api/ClubHouseTables/";

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }


        public async Task<List<T>> GetAsync(string email)
        {
            email = "?emailId=" + email;
            string url = WebServiceUrl + email;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
            return taskModels;

        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string urlId = "?id=" + Convert.ToString(id);
            string url = WebServiceUrl + urlId;
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string emailId)
        {
            emailId = "?emailId=" + emailId;
            string url = WebServiceUrl + emailId;
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }

}

