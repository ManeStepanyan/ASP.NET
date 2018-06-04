using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        using (var client = new HttpClient())
            {
            //    Product p = new Product();
                client.BaseAddress = new Uri("http://localhost:52004/");
               client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                var response = client.GetAsync("http://localhost:52004/api/Products/").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                } Console.ReadLine();
            } 
        }
    }
}