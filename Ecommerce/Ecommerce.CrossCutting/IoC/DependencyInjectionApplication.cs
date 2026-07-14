using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mapping;
using Ecommerce.Application.Services;
using Ecommerce.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ecommerce.CrossCutting.IoC
{
    public static class DependencyInjectionApplication
    {
        private static ILoggerFactory loggerFactory;

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //adicionar services

            services.AddScoped<IProdutosService, ProdutosService>();
            services.AddScoped<ICategoriasService, CategoriasService>();

            //adicionar automapper

            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(ProdutoDTOMappingProfile));
            });

            return services;
        }
    }
}
