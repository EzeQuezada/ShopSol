

namespace ShopSol.Aplication.Dto.Product
{
    public class ProductUpdateDto : ProductBaseDto
    {
        public DateTime modify_date { get; set; }
        public bool discontinued { get; set; }
        public int? modify_user { get; set; }
    }
}
