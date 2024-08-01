    

using ShopMonolitica.Web.Data.Entities;
using ShopSol.Aplication.Core;
using ShopSol.Aplication.Dto.Supplier;
using ShopSol.Persistence.DbObject;
using ShopSol.Persistence.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopSol.Aplication.Extension
{
    public static class SupplierValid
    {
        public static ServiceResult IsValidSupplier(this SupplierBaseDto supplierBaseDto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(supplierBaseDto.ContactName))
            {
                result.Message = "El nombre del suplidor es requerido.";
                return result;
            }

            if (supplierBaseDto.ContactName.Length > 30)
            {
                result.Message = "El nombre del suplidor no puede ser mayor de 40 caracteres.";
                return result;
            }

            if (supplierBaseDto.Address.Length > 60)
            {
                result.Message = "La dirección no puede ser mayor de 60 caracteres.";
                return result;
            }
            return result;
        }
        public static Suppliers ConvertSupplierSaveEntitieModel(this SupplierSaveDto supplierSaveModel)
        {
            return new Suppliers()
            {
                
                CompanyName = supplierSaveModel.CompanyName,
                ContactName = supplierSaveModel.ContactName,
                creation_date = supplierSaveModel.creation_date,
                creation_user = supplierSaveModel.creation_user,
                ContactTitle = supplierSaveModel.ContactTitle,
                Address = supplierSaveModel.Address,
                City = supplierSaveModel.City,
                PostalCode = supplierSaveModel.PostalCode,
                Country = supplierSaveModel.Country,
                Region = supplierSaveModel.Region,
                Phone = supplierSaveModel.Phone,
                Fax = supplierSaveModel.Fax,

            };

        }
        public static Suppliers SupplierUpdateEntitieModel(this SupplierUpdateDto supplierUpdateDto)

        {
            return new Suppliers()
            {
                CompanyName= supplierUpdateDto.CompanyName,
                ContactName = supplierUpdateDto.ContactName,
                ContactTitle = supplierUpdateDto.ContactTitle,
                Address = supplierUpdateDto.Address,
                City = supplierUpdateDto.City,
                PostalCode = supplierUpdateDto.PostalCode,
                Country = supplierUpdateDto.Country,
                Region = supplierUpdateDto.Region,
                Phone = supplierUpdateDto.Phone,
                Fax = supplierUpdateDto.Fax,
                modify_date = supplierUpdateDto.modify_date,

            };
        }
    }
}
