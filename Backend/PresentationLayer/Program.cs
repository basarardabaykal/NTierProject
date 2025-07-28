using AutoMapper;
using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using BusinessLayer.Profiles;
using BusinessLayer.Repository;
using BusinessLayer.Services.ControllerServices;
using BusinessLayer.Services.DbServices;
using BusinessLayer.Validations;
using CoreLayer.Entity;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NTierProject.Controllers;
using NTierProject.Middlewares;
using Serilog;
using System;
using System.Reflection;
using System.Text;
using DotNetEnv;
using DataLayer;
using BusinessLayer.Congrate.Services;

//serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .MinimumLevel.Debug()
    .CreateLogger();

//env
DotNetEnv.Env.Load();



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
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<AppUser>), typeof(UserRepository));
builder.Services.AddScoped(typeof(IGenericDbService<UserDTO>), typeof(UserDbService));
builder.Services.AddScoped(typeof(IGenericControllerService<UserDTO>), typeof(UserControllerService));
builder.Services.AddScoped(typeof(IGenericRepository<Company>), typeof(CompanyRepository));
builder.Services.AddScoped(typeof(IGenericDbService<CompanyDTO>), typeof(CompanyDbService));
builder.Services.AddScoped(typeof(IGenericControllerService<CompanyDTO>), typeof(CompanyControllerService));
builder.Services.AddScoped(typeof(IGenericRepository<Branch>), typeof(BranchRepository));
builder.Services.AddScoped(typeof(IGenericDbService<BranchDTO>), typeof(BranchDbService));
builder.Services.AddScoped(typeof(IGenericControllerService<BranchDTO>), typeof(BranchControllerService));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDbService, UserDbService>();
builder.Services.AddScoped<IUserControllerService, UserControllerService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyDbService, CompanyDbService>();
builder.Services.AddScoped<ICompanyControllerService, CompanyControllerService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthDbService, AuthDbService>();
builder.Services.AddScoped<IAuthControllerService, AuthControllerService>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IBranchDbService, BranchDbService>();
builder.Services.AddScoped<IBranchControllerService, BranchControllerService>();


//fluent validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(UserValidator).Assembly);

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//identity
builder.Services.AddIdentityCore<AppUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
/*builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOrAdmin", policy => policy.RequireRole("Admin", "User"));
});*/


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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


//serilog
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