using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Services.ControllerServices;
using BusinessLayer.Repository;
using BusinessLayer.Services.DbServices;
using BusinessLayer.Validations;
using BusinessLayer.Profiles;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using System.Reflection;
using FluentValidation;
using NTierProject.Controllers;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddRazorRuntimeCompilation();

//dependency injection
builder.Services.AddDbContext<UserDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDbService, UserDbService>();
builder.Services.AddScoped<IControllerService, HomeControllerService>();

//fluent validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(UserValidator).Assembly);

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddOpenApi();


//api test
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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