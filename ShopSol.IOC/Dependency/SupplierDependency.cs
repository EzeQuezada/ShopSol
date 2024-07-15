
using Microsoft.Extensions.DependencyInjection;
using ShopSol.Domain.Interfaces;
using ShopSol.Persistence.Repositories;
using System.Runtime.CompilerServices;

namespace ShopSol.IOC.Dependency
{
    public static class SupplierDependency
    {
        public static void AddSupplierDependecy(this IServiceCollection service)
        {
            service.AddScoped<ISupplierRepository, SupplierRepository>();
           
        }
    }
}
