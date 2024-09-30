using CozaStoreAPI.Common.ModelBinders;
using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.Services;
using CozaStoreAPI.Infrastructure.Data;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
            });

            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IWishesService, WishesService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IContactsService, ContactsService>();
            services.AddScoped<IEcontService, EcontService>();
            services.AddScoped<IShippingProviderService, ShippingProviderService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddHttpClient();

            return services;
        }

        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                }));

            return services;
        }

        public static IServiceCollection AddAppIdentity(this IServiceCollection services)
        {
            services.AddIdentityApiEndpoints<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    policy =>
                    {
                        policy.WithOrigins(
                            "https://localhost:5173", // React frontend URL
                            "https://cozastore.z1.web.core.windows.net" // New origin
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });

            return services;
        }

    }
}
