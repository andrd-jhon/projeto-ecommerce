using Ecommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ecommerce.Infrastructure.Context
{
    public class ApplicationDbContextFactory
        : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseMySql(
                "Server=localhost;DataBase=baseecommerce;Uid=root;Pwd=103005@Mysql",
                new MySqlServerVersion(new Version(8, 0, 42)));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}