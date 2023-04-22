using BindableEnum.Library.Filters;
using BindableEnum.Library.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var name = Assembly.GetExecutingAssembly().GetName().Name;
    var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{name}.xml");
    options.IncludeXmlComments(xmlPath);
    options.SchemaFilter<BindableEnumFilter>();
    options.MapType(typeof(BindableEnum<>), () => new OpenApiSchema { Type = "string" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
