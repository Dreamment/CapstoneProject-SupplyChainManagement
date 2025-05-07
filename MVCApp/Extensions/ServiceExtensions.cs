using Microsoft.EntityFrameworkCore;
using Repositories.Contratcs;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace MVCApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    b => b.MigrationsAssembly("MVCApp")));

        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
