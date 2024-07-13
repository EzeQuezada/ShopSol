

namespace ShopSol.Persistence.Models
{
    public class SupplierModel
    {
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }
        public DateTime? modify_date { get; set; }
        public int? ModifyUser { get; set; }
    }
}
