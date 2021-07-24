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
            ViewBag.Name = "Raihan";
            dynamic data = new ExpandoObject();
            ViewBag.Data = data;
            data.Id = 1;
            data.Title = "ViewBag learning";
            data.Roll = 112;


            //Passing Object

            ViewBag.Type = new BookModel() { Description= "jjjjjjjjjjjjjjjj" };

           
            
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
