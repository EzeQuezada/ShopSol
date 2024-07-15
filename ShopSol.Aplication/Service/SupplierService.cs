﻿

using Microsoft.Extensions.Logging;
using ShopMonolitica.Web.Data.Entities;
using ShopSol.Aplication.Core;
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
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.supplierRepository.GetAll();
            }
            catch (SuppliersExceptions dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los suplidores";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.supplierRepository.GetEntityBy(id);
            }
            catch (SuppliersExceptions dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los suplidores";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(SupplierRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.supplierRepository.Remove(new Suppliers()
                {
                    supplierid = model.supplierid,
                    deleted = model.deleted,
                    delete_date = model.modify_date,
                    delete_user = model.ModifyUser
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

        public ServiceResult Save(SupplierSaveDto model)
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

        public ServiceResult Update(SupplierUpdateDto model)
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
    }
}
