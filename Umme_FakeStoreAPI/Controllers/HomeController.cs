using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Umme_FakeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;



namespace Umme_FakeStoreAPI.Controllers
{

    public class Store
    {
        public class StoreItems
        {
            public int id { get; set; }
            public string title { get; set; }
            public float price { get; set; }
            public string description { get; set; }
            public string category { get; set; }
            public string image { get; set; }
            public Rating rating { get; set; }
        }

        public class Rating
        {
            public float rate { get; set; }
            public int count { get; set; }
        }

    }

    
    public class Program
        {
            HttpClient client = new HttpClient();

            static async Task Main(string[] args)
            {
                Program program = new Program();
                var data = await program.GetAllProducts();
                var JsonDes = Newtonsoft.Json.JsonConvert.DeserializeObject<Store>(data);
        }

            public async Task<string> GetAllProducts()
            {
                string response = await client.GetStringAsync("https://fakestoreapi.com/products");          
                return response;

            }
        }
}
