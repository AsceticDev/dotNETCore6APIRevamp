using dotNETCoreAPIRevamp.Data;
using Microsoft.EntityFrameworkCore;

namespace dotNETCoreAPIRevamp.Installers
{
    public static class DbConfig
    {
        public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
        {
            //Add Entity Framework Core
            var connString = builder.Configuration.GetConnectionString("JollyRoger");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connString));

            return builder;
        }
    }
}
