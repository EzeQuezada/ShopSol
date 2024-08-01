

using ShopSol.Aplication.Core;

using ShopSol.Aplication.Dto.Supplier;


namespace ShopSol.Aplication.Interfaces
{
    public interface ISupplierService 
    {
        ServiceResult GetSuppliers();
        ServiceResult GetSupplier(int supplierId);
        ServiceResult UpdateSuppliers(SupplierUpdateDto supplierUpdate);
        ServiceResult RemoveSuppliers(SupplierRemoveDto supplierRemove);
        ServiceResult SaveSuppliers(SupplierSaveDto supplierSave);

    }
}
