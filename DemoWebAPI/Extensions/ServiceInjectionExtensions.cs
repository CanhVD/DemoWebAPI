using DemoWebAPI.Repository;
using DemoWebAPI.Services;

namespace HRM.ApiService.Extensions
{
    public static class ServiceInjectionExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddScoped<SessionService>();
            services.AddScoped<AuthService>();

            // Add repository to the container.
            services.AddScoped<UserRepository>();
            return services;
        }
    }
}
