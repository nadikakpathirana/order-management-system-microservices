using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ProductService.Persistence.Context;
using ProductService.Application.Interfaces;

namespace ProductService.Persistence;

public static class ServiceExtensions
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductDbContext>(cfg =>
            cfg.UseSqlServer(configuration.GetConnectionString("ProductDbConnection")));

        services.AddScoped<IProductDbContext, ProductDbContext>();

    }
}
