using Microsoft.EntityFrameworkCore;
using ShopSol.Domain.Interfaces;
using ShopSol.Persistence.Context;
using ShopSol.Persistence.Repositories;
using ShopSol.IOC.Dependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShopContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));


//Agregar las dependencias del modulo Producto
builder.Services.AddSupplierDependecy();
builder.Services.AddProductDependency();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
