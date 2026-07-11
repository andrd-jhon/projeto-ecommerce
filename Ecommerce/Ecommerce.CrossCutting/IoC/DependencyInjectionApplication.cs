using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.CrossCutting.IoC
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //adicionar services

            services.AddScoped<IProdutosService, ProdutosService>();


            return services;
        }
    }
}
