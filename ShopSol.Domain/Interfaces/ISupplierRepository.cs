using ShopMonolitica.Web.Data.Entities;
using ShopSol.Common.Data.Repository;


namespace ShopSol.Domain.Interfaces
{   
    public interface ISupplierRepository : IBaseRepository<Suppliers,int>
    {
        List<Suppliers> GetSupplierById(int supplierId);
    }
}
