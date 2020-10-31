using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetProductById(Guid id);
    }

    //public interface ICatalogServiceRefit
    //{
    //    [Get("api/products")]
    //    Task<IEnumerable<ProductViewModel>> GetAll();

    //    [Get("api/products/{id}")]
    //    Task<ProductViewModel> GetById(Guid id);
    //}
}
