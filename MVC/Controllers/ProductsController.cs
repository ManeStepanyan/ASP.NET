using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var prodInfo = new List<Product>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["AddressWebAPI"]);

                client.DefaultRequestHeaders.Clear();
                // Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var res = client.GetAsync("api/Products/").Result;

                // Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    // Storing the response details recieved from web api   
                    var prodResponse = res.Content.ReadAsStringAsync().Result;

                    // Deserializing the response recieved from web api and storing into the Employee list  
                    prodInfo = JsonConvert.DeserializeObject<List<Product>>(prodResponse);

                }
                // returning the employee list to view  
                return View(prodInfo);
            }
        }
    }

}