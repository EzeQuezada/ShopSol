using ShopMonolitica.Web.Data.ProductModel;
using ShopSol.Web.Models;
using ShopSol.Web.Result.ProductSupplier;
using ShopSol.Web.Result.SupplierResult;

namespace ShopSol.Web.Service.IService
{
    public interface IProductService
    {

        Task<ProductGetListResult> GetList();

        Task<ProductGetResult> GetById(int id);
        Task<ProductSaveResult> Save(ProductSaveModel productSaveeModel);
        Task<ProductUpdateResult> Update(ProductUpdateModel productUpdateModel);
    }
}
