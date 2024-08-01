

namespace ShopSol.Aplication.Dto.Supplier
{
    public class SupplierDto
    {
        public int supplierid { get; set; }
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }
        public DateTime? modify_date { get; set; }
        public int? modifyUser { get; set; }
    }
}
