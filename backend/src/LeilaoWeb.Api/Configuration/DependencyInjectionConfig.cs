using LeilaoWeb.Api.Extensions;
using LeilaoWeb.Business.Intefaces;
using LeilaoWeb.Business.Notificacoes;
using LeilaoWeb.Business.Services;
using LeilaoWeb.Data.Context;
using LeilaoWeb.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using UsuarioWeb.Business.Services;

namespace LeilaoWeb.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ILeilaoRepository, LeilaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ILeilaoService, LeilaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}