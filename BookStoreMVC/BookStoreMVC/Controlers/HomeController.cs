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
        public ViewResult Index()
        {
            ViewData["Property1"] = "Mubasshir Raihan";
            ViewData["Property2"] = new BookModel() { Author = "Riya", Language = "Python" };
            return View();
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
