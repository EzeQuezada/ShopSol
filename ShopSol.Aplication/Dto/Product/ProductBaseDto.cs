

using ShopSol.Aplication.Dto.Supplier;

namespace ShopSol.Aplication.Dto.Product
{
    public abstract class ProductBaseDto : SupplierDto  
    {
        
        public string? productname { get; set; }

        public double unitprice { get; set; }

        public bool discontinued { get; set; }

    }
}
