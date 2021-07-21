using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Controlers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var obj = new { Id = 1, Name = "Raihan" };
            return View("AboutUs", obj);
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();            
        }

    }
}
