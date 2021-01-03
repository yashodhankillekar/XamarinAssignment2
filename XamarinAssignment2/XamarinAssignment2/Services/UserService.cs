using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinAssignment2.Models;
using Newtonsoft.Json;
using System.Linq;

namespace XamarinAssignment2.Services
{
    class UserService
    {
        string url;
        HttpClient client;

        public UserService()
        {
            url = "http://192.168.0.100:23614/api/UsersAPI";
            client = new HttpClient();
        }

        public async Task<List<UserInfo>> GetData()
        {
            List<UserInfo> users = new List<UserInfo>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<UserInfo>>(content);
            }

            return users;
        }

        public async Task<UserInfo> GetUser(UserInfo usr)
        {

            List<UserInfo> users = new List<UserInfo>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<UserInfo>>(content);
            }

            //check if user login is valid
            UserInfo loggedInUser = users.Where(e => e.UserName == usr.UserName && e.UserPassword == usr.UserPassword).First();

            return loggedInUser;
        }

        public async Task<UserInfo> PostUser(UserInfo user)
        {

            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;

            response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string respData = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<UserInfo>(respData);
            }
            return user;
        }
    }
}
