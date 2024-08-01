

using Microsoft.EntityFrameworkCore;
using ShopMonolitica.Web.Data.Entities;
using ShopSol.Domain.Interfaces;
using ShopSol.Persistence.Context;
using ShopSol.Persistence.DbObject;
using ShopSol.Persistence.Exceptions;
using ShopSol.Persistence.Extension;
using System.Linq;
using System.Linq.Expressions;

namespace ShopSol.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ShopContext context;

        public SupplierRepository(ShopContext context)
        {
            this.context = context;
        }
        public bool Exists(Expression<Func<Suppliers, bool>> filter)
        {
            return this.context.Suppliers.Any(filter);
        }

        public List<Suppliers> GetAll()
        {
            return this.context.Suppliers
                     
                     .ToList();

        }

        public List<Suppliers> GetSupplierById(int supplierId)
        {
            var suppliers = context.ValidateSupplierExist(supplierId);

            if (suppliers is null)
            {
                throw new SuppliersExceptions($"No se pudo encontrar el empleado con el id{supplierId}");
            }
            var SupplierList = new List<Suppliers> {suppliers};

            return SupplierList;
        }
        public Suppliers GetEntityBy(int id)
        {
            var Suppliers = context.Suppliers.Find(id).ConvertSupplierEntitieModel();

            if (Suppliers is null)
            {
                throw new SuppliersExceptions($"No se encontro el suplidor con el id {id}");
            }

            return Suppliers;
        }

        public void Remove(Suppliers entity)
        {
            Suppliers supplierToDelete = this.context.Suppliers.Find(entity.Id);

            supplierToDelete.deleted = entity.deleted;
            supplierToDelete.delete_date = entity.delete_date;
            supplierToDelete.delete_user = entity.delete_user;

            this.context.Suppliers.Update(supplierToDelete);
        }

        public void save(Suppliers entity)
        {
            Suppliers suppliersentity = entity.ConvertSupplierSaveEntitieModel();

            context.Suppliers.Add(suppliersentity);

            context.SaveChanges();
        }

        public void Update(Suppliers entity)
        {
            var updatedSuppliers = context.Suppliers.FirstOrDefault(c => c.Id == entity.Id);

            if (updatedSuppliers != null)
            {
                updatedSuppliers.SupplierUpdateEntitieModel(entity);
                context.Suppliers.Update(updatedSuppliers);
                context.SaveChanges();
            }
        }

       
    }
}
