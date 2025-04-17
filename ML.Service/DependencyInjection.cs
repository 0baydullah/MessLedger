using Microsoft.Extensions.DependencyInjection;

namespace ML.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            // services.AddScoped<IRoleService, RoleService>();

            return services;
        }
    }
}
