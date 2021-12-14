using BookStoreMVC.Models;
using BookStoreMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Controlers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
         _accountRepository = accountRepository;
        }



        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }


        [Route("signup")]
        [HttpPost]
        public async Task <IActionResult> SignUp(SignUpUserModel userModel)
        {

            if (ModelState.IsValid)
            {
                var result= await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(userModel);
                }

                ModelState.Clear();
            }
            return View();
        }


        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task <IActionResult> Login(SignInModel signInModel)
        {
      
            if (ModelState.IsValid)
            {
               var result= await _accountRepository.PasswordSignInAsync(signInModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid credentials");
               
            }

            return View();
        }




    }
}
