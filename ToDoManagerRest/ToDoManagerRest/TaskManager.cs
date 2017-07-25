using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ToDoManagerRest.Models;

namespace ToDoManagerRest
{
    public class TaskManager
    {
        const string Url = "http://10.0.2.2:8080/task_manager/v1/";
        private string authorizationKey;

        public HttpClient GetClient()
        {
            /*  HttpClient client = new HttpClient();
              if (string.IsNullOrEmpty(authorizationKey))
              {
                  authorizationKey = await client.GetStringAsync(Url);
                  authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
              }

              client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
              client.DefaultRequestHeaders.Add("Accept", "aaplication/json");*/

            return new HttpClient();
        }

        public async Task<string> Register(string name, string email, string password)
        {
            JObject user = new JObject(
                    new JProperty("name", "test"),
                    new JProperty("password", "test"),
                    new JProperty("email", "zzzzcom")
                );


            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(user.ToString());

            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url+"register", content);

            Debug.WriteLine("response : " + response.Content.ReadAsStringAsync().Result);

            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<String> Login(string email, string password)
        {
            User user = new User()
            {
                Email = email,
                Password = password
            };

            

            HttpClient client = GetClient();
            var response = await client.PostAsync(Url+"login", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<String>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IEnumerable<Models.Task>> GetAll()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url+"tasks");
          
            return JsonConvert.DeserializeObject<IEnumerable<Models.Task>>(result);
        }


    }
}
