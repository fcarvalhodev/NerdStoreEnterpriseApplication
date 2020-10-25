using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class AuthController : Controller
    {
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

            if (false) return View(userRegister);

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

            if (false) return View(userLogin);

            //Realizar o login na APP

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> logout()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
