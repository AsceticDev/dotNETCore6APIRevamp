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

            //Swagger Stuff
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNet Core 6 API Revamp", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            //Scope
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IIdentityService, IdentityService>();
            return services;
        }
    }
}
