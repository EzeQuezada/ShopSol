

using ShopMonolitica.Web.Data.Entities;
using ShopSol.Aplication.Core;
using ShopSol.Aplication.Dto.Product;


namespace ShopSol.Aplication.Interfaces
{
    public interface IProductService 
    {
        ServiceResult GetProducts();
        ServiceResult GetProduct(int productid);
        ServiceResult UpdateProducts(ProductUpdateDto productUpdate);
        ServiceResult RemoveProducts(ProductRemoveDto productsRemove);
        ServiceResult SaveProducts(ProductSaveDto productSave);
    }
}
