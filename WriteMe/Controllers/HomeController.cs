using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using WriteMe.Models;

namespace WriteMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly Logger _logger;

        public HomeController(Logger logger)
        {
            _logger = logger;
        }

        class MyClass
        {
            public string name { get; set; }
            public string surname { get; set; }

            public override string ToString() => $"Name = {name}, Surname = {surname}";
        } 
        class MyClass2
        {
            public string name { get; set; }
            public string surname { get; set; }

        }

        public IActionResult Index()
        {
            MyClass dima = new MyClass{name = "Dima", surname = "Senk"};
            MyClass2 dima2 = new MyClass2{name = "Xyi", surname = "Dimoooon"};
            _logger.Error(new Exception(),$"{dima} soset chlen {dima2} a", dima, dima2);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
