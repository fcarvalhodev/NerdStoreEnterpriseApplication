using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using NSE.WebApp.MVC.Models;
using System;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<AuthenticationResources> _localizer;

        public HomeController(IHtmlLocalizer<AuthenticationResources> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if(id == 500)
                FillError(id, modelError, _localizer["Error500Message"], _localizer["Error500Title"]);
            else if (id == 404)
                FillError(id, modelError, _localizer["Error404Message"], _localizer["Error404Title"]);
            else if (id == 403)
                FillError(id, modelError, _localizer["Error403Message"], _localizer["Error403Title"]);
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelError);
        }

        private void FillError(int id, ErrorViewModel modelError, LocalizedHtmlString message, LocalizedHtmlString title)
        {
            modelError.Message = message.Value;
            modelError.ErrorCode = id;
            modelError.Title = title.Value;
        }
    }
}
