using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStoreMVC.Models;

namespace BookStoreMVC.Controlers
{
    public class HomeController : Controller
    {
        [ViewData] 
        public string CustomProperty { get; set; }

        [ViewData]
        public string Title { get; set; }
        public ViewResult Index()
        {
            CustomProperty = "Hllo from View data";
            Title = "Home from controller";
            return View();
        }

        public ViewResult AboutUs()
        {
            Title = "About Us From controller";
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "Contact Us From controller";
            return View();            
        }

    }
}
