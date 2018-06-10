using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {               
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["AddressWebAPI"]);
                client.DefaultRequestHeaders.Accept.Clear();

                // I want JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // GET Method, waiting for result
                var response = client.GetAsync("api/Products/").Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("ID Name Price");
                    // could do in easier way
                    foreach (var item in JsonConvert.DeserializeObject<List<Product>>(response.Content.ReadAsStringAsync().Result))
                    {
                        Console.WriteLine("{0} {1} {2}", item.ID, item.Name, item.Price);
                    }
                }
                Console.ReadLine();
            }
        }
    }
}