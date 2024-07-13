

namespace ShopSol.Persistence.Models
{
    public class ProductModel
    {
        public int productid { get; set; }
        public string? productname { get; set; }

        public double unitprice { get; set; }

        public bool discontinued { get; set; } 
    }
}
