

using ShopSol.Aplication.Core;
using ShopSol.Persistence.Models;

namespace ShopSol.Aplication.Interfaces
{
    public interface ISupplierService
    {
        ServiceResult GetSupliers();
        ServiceResult GetSuplier(int id);
        ServiceResult UpdateSupliers(SupplierModel supplierUpdateModel);
        ServiceResult RemoveSupliers(SupplierModel supplierRemoveModel);
        ServiceResult SaveSupliers(SupplierModel supplierSaveModel);
    }
}
