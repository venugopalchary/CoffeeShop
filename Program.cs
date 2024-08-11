using CoffeeShopAPI.Configuration;
using CoffeeShopAPI.DBLayer;
using CoffeeShopAPI.DBLayer.Repository;
using CoffeeShopAPI.MyLogging;
using CoffeeShopAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<CoffeeShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopConnection")));
builder.Services.AddScoped<DbContext, CoffeeShopDbContext>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddTransient<IMyLogger, LogToServerMemory>();
builder.Services.AddScoped<ICoffeeShopService, CoffeeShopService>();
builder.Services.AddScoped<ICoffeeShopRepository, CoffeeShopRepository>();

builder.Services.AddMemoryCache();
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//    {
//        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.UseRouting();
//app.UseMvcWithDefaultRoute();
app.MapControllerRoute("default",
    "{controller=grid}/{action=index}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(name: "api",
//        pattern: "{controller}/{action}/{id?}");
//});

//app.MapControllers();


app.Run();
