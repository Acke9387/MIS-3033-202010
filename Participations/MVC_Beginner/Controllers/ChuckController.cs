using MVC_Beginner.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC_Beginner.Controllers
{
    public class ChuckController : Controller
    {
        // GET: Chuck
        public ActionResult Index()
        {
            ChuckAPI chuck;
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync("https://api.chucknorris.io/jokes/random").Result;
                chuck = JsonConvert.DeserializeObject<ChuckAPI>(json);

            }

            return View(chuck);
        }

        // /Chuck/Categories
        public ActionResult Categories()
        {
            ChuckAPI chuck;
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync("https://api.chucknorris.io/jokes/random").Result;
                chuck = JsonConvert.DeserializeObject<ChuckAPI>(json);

            }

            return View(chuck);
        }

    }
}