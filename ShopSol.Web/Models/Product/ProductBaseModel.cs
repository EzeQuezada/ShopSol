

using ShopSol.Web.Models;

namespace Shopsol.Web.Models
{
    public class ProductBaseModel : ProductsModel
    {
        public int creation_user { get; set; }

        public DateTime creation_date { get; set; }

        public object? modify_date { get; set; }
        public object? modify_user { get; set; }
    }
}
