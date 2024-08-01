

using ShopMonolitica.Web.Data.Entities;
using ShopSol.Aplication.Core;
using ShopSol.Aplication.Dto.Product;
using ShopSol.Persistence.Models;

namespace ShopSol.Aplication.Extension
{
    public static class ProductExtension
    {
       public static Products Toentity (this ProductRemoveDto dto)
        {
            return new Products
            {

               
                productname = dto.productname,
                unitprice = dto.unitprice,
                discontinued = dto.discontinued,
                deleted = dto.deleted,
                delete_date = dto.delete_date,
                delete_user = dto.delete_user,
                
            };
        }
        public static Products ToEntity(this ProductSaveDto dto)
        {
            return new Products()
            {
                productname = dto.productname,
                creation_user = dto.creation_user,
                creation_date = dto.creation_date,
                unitprice = dto.unitprice,
     
            };
        }

        public static void ConvertProductUpdateModel(this Products products, ProductUpdateDto productupdate)
        {
            products.productname = productupdate.productname;
            products.unitprice = productupdate.unitprice;
            products.discontinued = productupdate.discontinued;
                
        }
    }
}
