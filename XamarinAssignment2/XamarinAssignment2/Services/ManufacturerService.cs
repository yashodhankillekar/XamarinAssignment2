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
    class ManufacturerService
    {
        string url;
        HttpClient client;

        public ManufacturerService()
        {
            //url = "http://192.168.0.100:23614/api/ManufacturersAPI";
            url = "http://localhost:23614/api/ManufacturersAPI";
            client = new HttpClient();
        }

        public async Task<List<ManufacturerInfo>> GetData()
        {
            List<ManufacturerInfo> manufacturers = new List<ManufacturerInfo>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                manufacturers = JsonConvert.DeserializeObject<List<ManufacturerInfo>>(content);
            }

            return manufacturers;
        }
    }
}
