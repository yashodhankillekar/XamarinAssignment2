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
    class ProductService
    {
        string url;
        HttpClient client;

        public ProductService()
        {
            //url = "http://192.168.0.100:23614/api/ProductsAPI";
            url = "http://localhost:23614/api/ProductsAPI";
            client = new HttpClient();
        }

        public async Task<List<ProductInfo>> GetData()
        {
            List<ProductInfo> products = new List<ProductInfo>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ProductInfo>>(content);
            }

            return products;
        }

        public async Task<ProductInfo> PostProduct(ProductInfo product)
        {

            string json = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;

            response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string respData = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<ProductInfo>(respData);
            }
            return product;
        }

        public async Task<ProductInfo> PutProduct(ProductInfo product)
        {
            string json = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;

            response = await client.PutAsync(url + "/" + product.ProductRowId, content);
            if (response.IsSuccessStatusCode)
            {
                string respData = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<ProductInfo>(respData);
            }
            return product;
        }

        public async Task<ProductInfo> DeleteProduct(ProductInfo product)
        {
            HttpResponseMessage response = null;

            response = await client.DeleteAsync(url + "/" + product.ProductRowId);
            if (response.IsSuccessStatusCode)
            {
                string respData = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<ProductInfo>(respData);
            }
            return product;
        }
    }
}
