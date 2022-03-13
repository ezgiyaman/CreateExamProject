using Application.Models.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prensentation.Controllers
{
    [Authorize, AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AccountController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        #region LogIn

        [AllowAnonymous]
        public IActionResult LogIn(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home"); 
            }
          //  ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> LogIn(LoginDTO model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.Login(model);

                if (result.Succeeded)//eğer return başarılı ise; 
                {
                    return RedirectToAction(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi..!");
            }
            return View(model);
        }



        #endregion

        #region LogOut
        public async Task<IActionResult> LogOut()
        {
            await _appUserService.LogOut();
            return RedirectToAction(nameof(AccountController.LogIn), "Account");
        }

        #endregion


        #region Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.Register(model);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
            }
            return View(model);
        }
        #endregion
    }









}

