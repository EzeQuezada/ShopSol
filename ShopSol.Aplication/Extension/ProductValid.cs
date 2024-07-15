

using ShopMonolitica.Web.Data.Entities;
using ShopSol.Aplication.Core;
using ShopSol.Aplication.Dto.Product;
using ShopSol.Persistence.Models;

namespace ShopSol.Aplication.Extension
{
    public static class ProductValid
    {
        public static ServiceResult IsValidProduct(this ProductBaseDto product) 
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(product.productname))
            {
                result.Message = "El nombre del producto es requerido.";
                result.Success = false;
                return result;
            }

            if (product.productname.Length > 40)
            {
                result.Message = "El nombre del producto no puede ser mayor de 40 caracteres.";
                result.Success= false;
                return result;
            }
            if (product.unitprice == 0)
            {
                result.Message = "El precio no puede ser cero(0).";
                result.Success = false;
                return result;
            }
            return result;
        }
        public static Products ConvertProductSaveModel(this ProductSaveDto productsave)
        {
            return new Products()
            {
                productname = productsave.productname,
                creation_user = productsave.creation_user,
                creation_date = productsave.creation_date,
                unitprice = productsave.unitprice,
     
            };
        }

        public static Products ConvertProductUpdateModel(this ProductUpdateDto productupdate)
        {
            return new Products
            {
                productname = productupdate.productname,
                unitprice = productupdate.unitprice,
                discontinued = productupdate.discontinued,

            };
        }
    }
}
