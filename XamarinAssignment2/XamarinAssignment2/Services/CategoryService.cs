using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinAssignment2.Models;

namespace XamarinAssignment2.Services
{
    class CategoryService
    {
        string url;
        HttpClient client;

        public CategoryService()
        {
            //url = "http://192.168.0.100:23614/api/CategoriesAPI";
            url = "http://localhost:23614/api/CategoriesAPI";
            client = new HttpClient();
        }

        public async Task<List<CategoryInfo>> GetData()
        {
            List<CategoryInfo> categories = new List<CategoryInfo>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<CategoryInfo>>(content);
            }

            return categories;
        }
    }
}
