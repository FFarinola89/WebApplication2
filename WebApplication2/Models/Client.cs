using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication2.Models
{
    public class Client
    {
        public async Task<List<Tool>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.0.0.59:51699/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                List<Tool> tools = new List<Tool>();
                HttpResponseMessage response = await client.GetAsync("/api/tool");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tools = JsonConvert.DeserializeObject<List<Tool>>(content);
                }

                return tools;
            }
        }
    }
}