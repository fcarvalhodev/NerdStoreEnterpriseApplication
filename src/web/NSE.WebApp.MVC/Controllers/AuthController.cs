using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly NSE.WebApp.MVC.Services.IAuthenticationService _authenticationService;

        public AuthController(NSE.WebApp.MVC.Services.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

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

            //Api - Registrar usuário
            var result = await _authenticationService.Register(userRegister);

            await RealizeLogin(result);

            //Realizar o login na APP

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid) return View(userLogin);

            //Api - Registrar usuário
            var result = await _authenticationService.Login(userLogin);
            await RealizeLogin(result);
            
            //Realizar o login na APP

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> logout()
        {
            return RedirectToAction("Index", "Home");
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

        private static JwtSecurityToken GetTokenFormat(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
