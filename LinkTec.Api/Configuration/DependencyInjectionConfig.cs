using Linktec.Api.Notificacoes;
using LinkTec.Api.Entities;
using LinkTec.Api.Extensions;
using LinkTec.Api.Infrastructure.Database;
using LinkTec.Api.Interfaces;
using LinkTec.Api.Repository;
using LinkTec.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LinkTec.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ApplicationDBContext>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IContatoClienteRepository,ContatoClienteRepository>();
            services.AddScoped<IContatoClienteService, ContatoClienteService>();
            services.AddScoped<IParceiroRepository, ParceiroRepository>();
            services.AddScoped<IParceiroService, ParceiroService>();
            services.AddScoped<IPropostaSolicitacaoRepository, PropostaSolicitacaoRepository>();
            services.AddScoped<ISolicitacaoServicoRepository, SolicitacaoServicoRepository>();
            services.AddScoped<ISolicitacaoDeServicoService, SolicitacaoDeServicoService>();
            services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IOfertanteCertificadoRepository, OfertanteCertificadoRepository>();
            services.AddScoped<IUser, AspNetUser>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.Configure<Models.EmailTemplate>(configuration.GetSection("EmailTemplate"));

            return services;
        }
    }
}
