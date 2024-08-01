using ShopSol.Web.Service.IService;
using ShopSol.Web.Service.Service;
using ShopSol.Web.Services.IServvice;
using ShopSol.Web.Services.Services;

namespace ShopProMa.Web.Dependencias
{
    public static class Dependencies
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            #region "HttClient"
            service.AddHttpClient<ISupplierService, SupplierServices>();
            service.AddHttpClient<IProductService, ProductSupplierServices>();
            
            #endregion

            #region "AddScope"
            service.AddScoped<ISupplierService, SupplierServices>();
            service.AddScoped<IProductService, ProductSupplierServices>();
            
            #endregion
        }
    }
}
