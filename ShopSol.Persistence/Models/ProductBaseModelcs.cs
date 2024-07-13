

namespace ShopSol.Persistence.Models
{
    public class ProductBaseModel :ProductModel
    {
        public int creation_user { get; set; }

        public DateTime creation_date { get; set; }

    }
}
