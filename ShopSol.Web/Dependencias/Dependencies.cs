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
            
            #endregion

            #region "AddScope"
            service.AddScoped<ISupplierService, SupplierServices>();
            
            #endregion
        }
    }
}
