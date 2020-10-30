using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class AuthController : MainController
    {
        private readonly NSE.WebApp.MVC.Services.IAuthenticationService _authenticationService;

        public AuthController(NSE.WebApp.MVC.Services.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        #region .: Register :.

        [HttpGet]
        [Route("new-account")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("new-account")]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid) return View(userRegister);

            var result = await _authenticationService.Register(userRegister);
            if (ReponseHasErrors(result.ResponseResult)){
                return View(userRegister);
            }

            await RealizeLogin(result);
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region .: Login :.

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid) return View(userLogin);

            var result = await _authenticationService.Login(userLogin);
            if (ReponseHasErrors(result.ResponseResult))
            {
                return View(userLogin);
            }

            await RealizeLogin(result);

            if(string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

            return LocalRedirect(returnUrl);
        }

        private async Task RealizeLogin(UserResponseLogin userResponseLogin)
        {
            var token = GetTokenFormat(userResponseLogin.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", userResponseLogin.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
        }


        #endregion

        #region .: Logout :.


        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        #endregion
        
    }
}
