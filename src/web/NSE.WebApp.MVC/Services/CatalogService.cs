using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace NSE.WebApp.MVC.Services
{
    public class CatalogService : Service, ICatalogService
    {
        private readonly HttpClient _httpClient;


        public CatalogService(HttpClient httpClient,
            IOptions<AppSettings> settings
            )
        {
            _httpClient = httpClient;
            httpClient.BaseAddress = new Uri(settings.Value.AuthenticationUrl);
        }


        public async Task<ProductViewModel> GetProductById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/catalog/products/{id}");
            HandleErrorsResponse(response);

            return await DeserializeObjectResponse<ProductViewModel>(response);
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var response = await _httpClient.GetAsync("/catalog/products");
            HandleErrorsResponse(response);

            return await DeserializeObjectResponse<IEnumerable<ProductViewModel>>(response);
        }
    }
}
