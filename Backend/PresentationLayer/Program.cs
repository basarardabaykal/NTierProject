using AutoMapper;
using BusinessLayer.Dto;
using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Profiles;
using BusinessLayer.Repository;
using BusinessLayer.Services.ControllerServices;
using BusinessLayer.Services.DbServices;
using BusinessLayer.Validations;
using CoreLayer.Entity;
using DataLayer;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierProject.Controllers;
using NTierProject.Middlewares;
using Serilog;
using System;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .MinimumLevel.Debug()
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddControllers().AddRazorRuntimeCompilation();

//dependency injection
builder.Services.AddDbContext<DataLayer.DbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<AppUser>), typeof(UserRepository));
builder.Services.AddScoped(typeof(IGenericDbService<UserDTO>), typeof(UserDbService));
builder.Services.AddScoped(typeof(IGenericControllerService<UserDTO>), typeof(UserControllerService));
builder.Services.AddScoped(typeof(IGenericRepository<Company>), typeof(CompanyRepository));
builder.Services.AddScoped(typeof(IGenericDbService<CompanyDTO>), typeof(CompanyDbService));
builder.Services.AddScoped(typeof(IGenericControllerService<CompanyDTO>), typeof(CompanyControllerService));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDbService, UserDbService>();
builder.Services.AddScoped<IUserControllerService, UserControllerService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyDbService, CompanyDbService>();
builder.Services.AddScoped<ICompanyControllerService, CompanyControllerService>();


//fluent validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(UserValidator).Assembly);

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//identity
builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<DataLayer.DbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});


//builder.Services.AddOpenApi();


//api test
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//serilog
builder.Host.UseSerilog();

var app = builder.Build();

//cors
app.UseCors("AllowAll");

//global exception handler
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



try
{
    Log.Information("Starting up the app");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "App terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}