using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ProductService.Persistence;

public static class ServiceExtensions
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
    }
}
