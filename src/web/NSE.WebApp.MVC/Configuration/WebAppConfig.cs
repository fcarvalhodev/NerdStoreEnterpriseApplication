﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using System.Collections.Generic;
using System.Globalization;

namespace NSE.WebApp.MVC.Configuration
{
    public static class WebAppConfig
    {
        public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            var supportedCultures = new List<CultureInfo>
            {
             new CultureInfo("en-US"),
             new CultureInfo("pt-BR")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

            services.Configure<AppSettings>(configuration);
        }

        public static void UseMvcConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var localizationOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();

            app.UseRequestLocalization(localizationOption.Value);

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error/500");
            //    app.UseStatusCodePagesWithRedirects("/Error/{0}");
            //    app.UseHsts();
            //}

            app.UseExceptionHandler("/Error/500");
            app.UseStatusCodePagesWithRedirects("/Error/{0}");
            app.UseHsts();


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Catalog}/{action=Index}/{id?}");
            });
        }

    }
}
