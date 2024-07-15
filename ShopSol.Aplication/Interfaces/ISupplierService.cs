

using ShopSol.Aplication.Core;
using ShopSol.Aplication.Dto.Supplier;
using ShopSol.Persistence.Models;

namespace ShopSol.Aplication.Interfaces
{
    public interface ISupplierService : IBaseService<SupplierSaveDto, SupplierUpdateDto,
                                 SupplierRemoveDto>
    {
     
    }
}
