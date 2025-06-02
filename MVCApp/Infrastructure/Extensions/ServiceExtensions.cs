using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;
using System.Globalization;

namespace MVCApp.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    b => b.MigrationsAssembly("MVCApp")));

        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthenticationManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ITenderService, TenderManager>();
            services.AddScoped<IBidService, BidManager>();
            services.AddScoped<ISupplierService, SupplierManager>();
            services.AddScoped<ITenderCategoryService, TenderCategoryManager>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>( options =>
                { 
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "LoginCookie";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
        }

        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
            });
        }
        
        public static async Task AddInitialPassword(IRepositoryManager _repositoryManager)
        {
            var user = await _repositoryManager.User.FindByConditionAsync(u => u.UserName == "Emre", false);
            if (user != null)
            {
                if (user.PasswordHash != null)
                {
                    return;
                }
                var passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, "emre");
                await _repositoryManager.User.UpdateAsync(user);
                try
                {
                    await _repositoryManager.SaveAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static void ConfigureLocalization(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            var supportedCultures = new[] { new CultureInfo("tr-TR") };
            services.Configure<Microsoft.AspNetCore.Builder.RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
}
