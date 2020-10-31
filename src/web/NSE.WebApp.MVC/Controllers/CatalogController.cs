using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class CatalogController : MainController
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        [Route("")]
        [Route("ShowCase")]
        public async Task<IActionResult> Index()
        {
            return View(await _catalogService.GetAll());
        }

        [HttpGet]
        [Route("ProductDetail/{id}")]
        public async Task<IActionResult> ProductDetail(Guid id)
        {
            return View(await _catalogService.GetProductById(id));
        }
        
    }
}
