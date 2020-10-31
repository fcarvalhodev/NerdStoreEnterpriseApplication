using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using Polly;
using Polly.Extensions.Http;
using System;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>(); //chamado uma instancia de cada vez por request.

            services.AddHttpClient<IAuthenticationService, AuthenticationService>();

            //var retryWaitPolicy = HttpPolicyExtensions
            //    .HandleTransientHttpError()
            //    .WaitAndRetryAsync(new[]
            //    {
            //        TimeSpan.FromSeconds(1),
            //        TimeSpan.FromSeconds(5),
            //        TimeSpan.FromSeconds(3)
            //    }, (outcome, timespan, retryCount, context) =>
            //    {
            //        Console.ForegroundColor = ConsoleColor.Blue;
            //        Console.WriteLine($"Tentando pela {retryCount} vez!");
            //        Console.ForegroundColor = ConsoleColor.White;
            //    });

            services.AddHttpClient<ICatalogService, CatalogService>()
                  .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            //      .AddPolicyHandler(retryWaitPolicy);

            //services.AddHttpClient("Refit", options =>
            //{
            //    options.BaseAddress = new Uri(configuration.GetSection("CatalogUrl").Value);
            //}).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //  .AddTypedClient(Refit.RestService.For<ICatalogServiceRefit>);


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();
        }

    }
}
