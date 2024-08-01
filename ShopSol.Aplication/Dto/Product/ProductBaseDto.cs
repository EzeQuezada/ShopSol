

using ShopSol.Aplication.Dto.Supplier;
using System.ComponentModel.DataAnnotations;

namespace ShopSol.Aplication.Dto.Product
{
    public abstract class ProductBaseDto 
    {
        [Key]
        public int productid { get; set; }

        [StringLength(40,ErrorMessage ="El nombre no puede exceder de 40 caracteres")]
        public string? productname { get; set; }

        [DataType(DataType.Currency)]
        public double unitprice { get; set; }

        public bool discontinued { get; set; }

 


    }
}
