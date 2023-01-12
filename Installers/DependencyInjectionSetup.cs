using dotNETCoreAPIRevamp.Services;
using Microsoft.OpenApi.Models;

namespace dotNETCoreAPIRevamp.Installers
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddControllers();
            services.AddEndpointsApiExplorer();

          
            //Scope
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IIdentityService, IdentityService>();
            return services;
        }
    }
}
