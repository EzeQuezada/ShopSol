

using Microsoft.Extensions.Logging;
using ShopMonolitica.Web.Data.Entities;
using ShopSol.Aplication.Core;
using ShopSol.Aplication.Dto.Product;
using ShopSol.Aplication.Dto.Supplier;
using ShopSol.Aplication.Extension;
using ShopSol.Aplication.Interfaces;
using ShopSol.Domain.Interfaces;
using ShopSol.Persistence.Exceptions;
using ShopSol.Persistence.Repositories;

namespace ShopSol.Aplication.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly ILogger<SupplierService> logger;

        public SupplierService(ISupplierRepository supplierRepository,
                                        ILogger<SupplierService>logger)
        {
            this.supplierRepository = supplierRepository;
            this.logger = logger;
        }
        public ServiceResult GetSuppliers()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var suppliers = this.supplierRepository.GetAll();
                result.Data = (from supplier in supplierRepository.GetAll()
                               where supplier.deleted == false
                               select new SupplierBaseDto()
                               {
                                   supplierid = supplier.Id,
                                   CompanyName = supplier.CompanyName,
                                   ContactName = supplier.ContactName,
                                   creation_date = supplier.creation_date,
                                   creation_user = supplier.creation_user,
                               }).OrderByDescending(cd=>cd.creation_date).ToList();   
            }

            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los suplidores";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetSupplier(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = (from supplier in supplierRepository.GetAll()
                               where supplier.Id == id
                               && supplier.deleted == false
                               select new SupplierBaseDto()
                               {
                                   supplierid = supplier.Id,
                                   CompanyName = supplier.CompanyName,
                                   ContactName = supplier.ContactName,
                                   creation_date = supplier.creation_date,
                                   creation_user = supplier.creation_user,
                               }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los suplidores";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveSuppliers(SupplierRemoveDto productsRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.supplierRepository.Remove(new Suppliers()
                {   
                    Id = productsRemove.supplierid,
                    deleted = productsRemove.deleted,
                    delete_date = productsRemove.modify_date,
                    delete_user = productsRemove.modifyUser
                });

                result.Message = "Suplidor eliminado correctamente.";

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el suplidor.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult SaveSuppliers(SupplierSaveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                if (!model.IsValidSupplier().Success)
                    return result;

                Suppliers suppliers = model.ConvertSupplierSaveEntitieModel();

                this.supplierRepository.save(suppliers);

                result.Message = "Suplidor guardado correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el suplidor";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateSuppliers(SupplierUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            if (!model.IsValidSupplier().Success)
                return result;

            try
            {
                Suppliers suppliers = model.SupplierUpdateEntitieModel();

                suppliers.modify_date = DateTime.Now;
                suppliers.creation_user = 1;


                this.supplierRepository.Update(suppliers);

                result.Message = "suplidor actualizado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error actualizando el suplidor";
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }

            return result;
        }

        

        //public ServiceResult SaveSuppliers(SupplierSaveDto supplierSave)
        //{
        //      ServiceResult result = new ServiceResult();

        //    try
        //    {
        //        result = EntityValidator<ProductSaveDto>.Validate(supplierSave);
        //        if (!result.Success)
        //        {
        //            return result;
        //        }

        //        Suppliers suppliers = model.ConvertSupplierSaveEntitieModel();

        //        this.supplierRepository.save(suppliers);

        //        result.Message = "Suplidor guardado correctamente.";

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Success = false;
        //        result.Message = "Error guardando el suplidor";
        //        this.logger.LogError($"{result.Message}", ex.ToString());
        //    }
        //    return result;
        //}
    }
}
