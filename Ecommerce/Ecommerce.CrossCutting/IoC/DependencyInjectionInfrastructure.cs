using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Context;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.CrossCutting.IoC
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 42))));

            //repo generico
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //repositórios específicos
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //Unit of Work

            return services;
        }
        
    }
}
