using ShopMonolitica.Web.Data.Entities;
using ShopSol.Persistence.DbObject;
using ShopSol.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSol.Persistence.Extension
{
    public static class ProductExtension
    {
        public static Products ConvertProductEntitieModel(this Products products)
        {
            return new Products()
            {
                productid = products.productid,
                productname = products.productname,
                unitprice = products.unitprice,
                discontinued = products.discontinued,

            };
        }
        public static Products ConvertProductSaveModel(this Products productsave)
        {
            return new Products()
            {
                productname = productsave.productname,
                creation_user = productsave.creation_user,
                creation_date = productsave.creation_date,
                unitprice = productsave.unitprice,
            };
        }
        public static ProductModel ConvertProductUpdateModel(this Products productupdate)
        {
            return new ProductModel
            {
                productname = productupdate.productname,
                unitprice = productupdate.unitprice,
                discontinued = productupdate.discontinued,

            };
        }
    }
}
