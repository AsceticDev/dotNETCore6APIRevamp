using dotNETCoreAPIRevamp.Data;
using Microsoft.EntityFrameworkCore;

namespace dotNETCoreAPIRevamp.Installers
{
    public static class DbConfig
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var connString = builder.Configuration.GetConnectionString("JollyRoger");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connString));


            return services;
        }
    }
}
