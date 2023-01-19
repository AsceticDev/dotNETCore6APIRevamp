using dotNETCoreAPIRevamp.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text;

namespace dotNETCoreAPIRevamp.Installers
{
    public static class Authentication
    {
        public static WebApplicationBuilder AddAuthJwt(this WebApplicationBuilder builder)
        {
            //JWT Shenanigans mapping the Jwt in appsettings.json to the jwtSettings object.
            var jwtSettings = new JwtSettings();
            builder.Configuration.Bind("Jwt", jwtSettings);
            builder.Services.AddSingleton(jwtSettings);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = Debugger.IsAttached ? TimeSpan.Zero : TimeSpan.FromMinutes(10)
                //ClockSkew = TimeSpan.Zero,
            };

            builder.Services.AddSingleton(tokenValidationParameters);


            //AUTHENTICATION
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.SaveToken = true;
                //The MetadataAddress or Authority must use HTTPS unless disabled for development
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = tokenValidationParameters;
            });

            builder.Services.AddAuthorization();

            return builder;
        }
    }
}