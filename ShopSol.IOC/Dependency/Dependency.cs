

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShopSol.Aplication.Interfaces;
using ShopSol.Aplication.Service;
using ShopSol.Domain.Interfaces;
using ShopSol.Infraestructura.Logger.Interfaces;
using ShopSol.Infraestructura.Logger.Service;
using ShopSol.Persistence.Repositories;

namespace ShopSol.IOC.Dependency
{
    public static class Dependency
    {
        public static void AddProductSupplierDependency(this IServiceCollection service)
        {
            #region"Repositorios"
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<ISupplierRepository, SupplierRepository>();
            #endregion

            #region "Service"
            service.AddTransient<IProductService, ProductService>();
            service.AddTransient<ISupplierService, SupplierService>();
            #endregion

            service.AddScoped<ILoggerService, LoggerService>();
        }
    }
}
