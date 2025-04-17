using Microsoft.Extensions.DependencyInjection;

namespace ML.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            //  services.AddScoped<IRoleRepo, RoleRepo>();


            return services;
        }
    }
    
}
