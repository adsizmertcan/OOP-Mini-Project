﻿using DemoProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel P)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _signInManager.PasswordSignInAsync(P.UserName, P.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Hatalı Kullancı veya Şifre");
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Hatalı Kullancı veya Şifre");
                }
               
            }
            return View();
        }

        //LogOut işlemi
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
