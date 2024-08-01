
using ShopSol.Web.Models;
using ShopSol.Web.Result.SupplierResult;


namespace ShopSol.Web.Services.IServvice
{
    public interface ISupplierService
    {
        Task<SupplierGetListResult> GetList();

        Task<SupplierGetResult> GetById(int id);
        Task<SupplierSaveResult> Save(SupplierSaveModel supplierSaveModel);
        Task<SupplierUpdateResult> Update(SupplierUpdateModel supplierUpdateModel);
    }
}
