using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.Identity.API.Data;
using NSE.Identity.API.Extensions;
using NSE.WebAPI.Core.Identity;

namespace NSE.Identity.API.Configuration
{
    public static class IdentityConfig
    {

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,  IConfiguration configuration)
        {
            //Configuração de conexão do banco de dados
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

          
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMessagesPortuguese>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddJsonWebTokenConfig(configuration);

            return services;
        }

 
    }
}
