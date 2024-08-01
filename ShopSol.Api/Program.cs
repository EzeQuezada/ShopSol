using Microsoft.EntityFrameworkCore;

using ShopSol.Persistence.Context;

using ShopSol.IOC.Dependency;
using ShopSol.Infraestructura.Logger.Interfaces;
using ShopSol.Infraestructura.Logger.Service;



var builder = WebApplication.CreateBuilder(args);

// Configurando el context
builder.Services.AddDbContext<ShopContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));


//Agregar las dependencias del modulo 

builder.Services.AddProductSupplierDependency();




// Add services to the container.
builder.Services.AddControllers();
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
