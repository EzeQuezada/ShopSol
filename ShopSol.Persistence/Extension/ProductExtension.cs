using ShopMonolitica.Web.Data.Entities;
using ShopSol.Persistence.Context;


namespace ShopSol.Persistence.Extension
{
    public static class ProductExtension
    {
  
     
        public static void ConvertProductUpdateModel(this Products productupdate, Products entity)
        {


            productupdate.productname = entity.productname;
            productupdate.unitprice = entity.unitprice;
            productupdate.discontinued = entity.discontinued;

            
        }
        public static Products ValidateProductExist(this ShopContext context,int productid) 
        {
            var productos = context.Products.Find(productid);
            return productos;
        }
       
    }
}
