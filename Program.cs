﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("D:/vscode/react+dotnet api/MyProject/appsettings.json", optional: false, reloadOnChange: true);
builder.WebHost.UseUrls("http://localhost:5002");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Authentication Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
        };

        var jwtKey = builder.Configuration["Jwt:Key"];
        if (!string.IsNullOrEmpty(jwtKey))
        {
            options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        }
    });

var app = builder.Build();

builder.Environment.EnvironmentName = "Development"; // Set environment to Development for testing Swagger
app.UseSwagger();
app.UseSwaggerUI();


app.UseCors(builder => 
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

Console.WriteLine("Registered Routes:");
foreach (var endpoint in app.Services.GetRequiredService<Microsoft.AspNetCore.Routing.EndpointDataSource>().Endpoints)
{
    Console.WriteLine(endpoint.DisplayName);
}

// Log to confirm that MapControllers was called
Console.WriteLine("MapControllers called.");

// Log to confirm registered routes after application starts
Console.WriteLine("Routes after application starts:");
foreach (var endpoint in app.Services.GetRequiredService<Microsoft.AspNetCore.Routing.EndpointDataSource>().Endpoints)
{
    Console.WriteLine(endpoint.DisplayName);
}


// Log to confirm registered routes after application starts
Console.WriteLine("Routes after application starts:");
foreach (var endpoint in app.Services.GetRequiredService<Microsoft.AspNetCore.Routing.EndpointDataSource>().Endpoints)
{
    Console.WriteLine(endpoint.DisplayName);
}

app.Run();
