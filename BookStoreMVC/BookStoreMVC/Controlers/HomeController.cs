using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Controlers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome to MVC";
        }

    }
}
