

using ShopMonolitica.Web.Data.Entities;
using ShopSol.Aplication.Core;
using ShopSol.Aplication.Dto.Product;
using ShopSol.Aplication.Dto.Supplier;
using ShopSol.Persistence.Models;

namespace ShopSol.Aplication.Interfaces
{
    public interface IProductService : IBaseService<ProductSaveDto, ProductUpdateDto,
                                ProductRemoveDto >
    {
    }
}
