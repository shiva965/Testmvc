using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductPracticeMvc.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProductPracticeMvc.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44384/api");
        HttpClient client;
        public ProductController()
        {
            client =new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<Product> model = new List<Product>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ProductDetails/GetProductDetails").Result;
                if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<Product>>(data);
            }
            return View(model);
        }
    }
}
