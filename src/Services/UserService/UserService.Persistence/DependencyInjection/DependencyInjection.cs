using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Persistence.Context;

namespace UserService.Persistence.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration _)
    {
        services.AddDbContext<IdentityDbContext>(
            options => options.UseInMemoryDatabase("IdentityDb"));

        return services;
    }
}
