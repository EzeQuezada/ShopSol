

using ShopMonolitica.Web.Data.Entities;
using ShopSol.Persistence.Context;
using ShopSol.Persistence.Models;

namespace ShopSol.Persistence.Extension
{
    public static class SupplierExtension
    {
        public static Suppliers ConvertSupplierEntitieModel(this Suppliers suppliers)
        {
            return new Suppliers()
            {
             
                
                CompanyName = suppliers.CompanyName,
                ContactName = suppliers.ContactName,
                ContactTitle = suppliers.ContactTitle,
                Address = suppliers.Address,
                City = suppliers.City,
                PostalCode = suppliers.PostalCode,
                Country = suppliers.Country,
                Region = suppliers.Region,
                Phone = suppliers.Phone,
                Fax = suppliers.Fax,
            };
        }

        public static Suppliers ConvertSupplierSaveEntitieModel(this Suppliers supplierSaveModel)
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
        public static void SupplierUpdateEntitieModel(this Suppliers  suppliers, Suppliers supplierUpdateModel)

        {


            
            suppliers.CompanyName = supplierUpdateModel.CompanyName;
            suppliers.ContactName = supplierUpdateModel.ContactName;
            suppliers.ContactTitle = supplierUpdateModel.ContactTitle;
            suppliers.Address = supplierUpdateModel.Address;
            suppliers.City = supplierUpdateModel.City;
            suppliers.PostalCode = supplierUpdateModel.PostalCode;
            suppliers.Country = supplierUpdateModel.Country;
            suppliers.Region = supplierUpdateModel.Region;
            suppliers.Phone = supplierUpdateModel.Phone;
            suppliers.Fax = supplierUpdateModel.Fax;
            suppliers.modify_date = supplierUpdateModel.modify_date;


        }
        public static Suppliers ValidateSupplierExist(this ShopContext context, int supplierId)
        {
            var suppliers = context.Suppliers.Find(supplierId);
            return suppliers;
        }
    }
}

