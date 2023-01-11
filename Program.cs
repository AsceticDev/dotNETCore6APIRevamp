using dotNETCoreAPIRevamp.Data;
using dotNETCoreAPIRevamp.Installers;
using dotNETCoreAPIRevamp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthJwt(builder);

// Add services to the container.
builder.Services.RegisterServices();
//Db Stuff
builder.Services.ConfigureDatabase(builder);
//Identity
builder.Services.ConfigureIdentity();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
