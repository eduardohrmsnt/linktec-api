using HealthChecks.MySql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LinkTec.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "3f5820e847e6443996645caa77afa55c";
                o.LogId = new Guid("8b136b17-7edd-43e7-be83-876266ee6e30");
            });

            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = "3f5820e847e6443996645caa77afa55c";
                    options.LogId = new Guid("8b136b17-7edd-43e7-be83-876266ee6e30");
                    options.HeartbeatId = "d7578295dda54e92b4d6acb91d71aae8";

                })
                .AddCheck("Produtos", new MySqlHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddMySql(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            services.AddHealthChecks()
                .AddMySql(configuration.GetConnectionString("DefaultConnection"));

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
