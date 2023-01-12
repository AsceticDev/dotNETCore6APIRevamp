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

builder.AddAuthJwt();
// Add services to the container.
builder.Services.RegisterServices();
//Db Stuff
builder.ConfigureDatabase();
//Identity
builder.Services.ConfigureIdentity();
//Swagger
builder.Services.ConfigureSwagger();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
