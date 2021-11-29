using LinkTec.Api.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkTec.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, string mySqlConnection)
        {
            services.AddDbContextPool<ApplicationIdentityDBContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
            services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>().
                AddEntityFrameworkStores<ApplicationIdentityDBContext>()
                .AddDefaultTokenProviders();


            return services;
        }
    }
}
