

using Microsoft.Extensions.DependencyInjection;
using ShopSol.Domain.Interfaces;
using ShopSol.Persistence.Repositories;

namespace ShopSol.IOC.Dependency
{
    public static class ProductDependency
    {
        public static void AddProductDependency(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository,ProductRepository>();

        }
    }
}
