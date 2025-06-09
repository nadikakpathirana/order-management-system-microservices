using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ProductService.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ProductService.Persistence;

public static class ServiceExtensions
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductDbContext>(cfg =>
            cfg.UseSqlServer(configuration.GetConnectionString("ProductDbConnection")));
    }
}
