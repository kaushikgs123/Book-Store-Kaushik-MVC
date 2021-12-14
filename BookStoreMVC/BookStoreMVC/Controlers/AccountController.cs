using BookStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Controlers
{
    public class AccountController : Controller
    {
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }


        [Route("signup")]
        [HttpPost]
        public IActionResult SignUp(SignUpUserModel userModel)
        {

            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }
            return View();
        }
    }
}
