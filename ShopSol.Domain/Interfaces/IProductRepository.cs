
using ShopMonolitica.Web.Data.Entities;
using ShopSol.Common.Data.Repository;


namespace ShopSol.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Products,int>
    {
        List<Products> GetProductsById(int productId);

    }
}
