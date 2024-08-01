using ShopSol.Web.Models;
using ShopSol.Web.Result.Base;

namespace ShopSol.Web.Result.SupplierResult
{
    public class SupplierGetListResult :BaseResult<List<SupplierBaseModel>>
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
}
