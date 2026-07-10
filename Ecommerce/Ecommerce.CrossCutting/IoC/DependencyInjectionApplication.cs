using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.CrossCutting.IoC
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //adicionar services

            return services;
        }
    }
}
