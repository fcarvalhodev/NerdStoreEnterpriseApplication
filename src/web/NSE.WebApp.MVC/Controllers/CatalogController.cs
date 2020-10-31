using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class CatalogController : MainController
    {
        [HttpGet]
        [Route("")]
        [Route("showcase")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        [Route("product-detail/{id}")]
        public async Task<IActionResult> ProductDetail(Guid id)
        {
            return View();
        }
        
    }
}
