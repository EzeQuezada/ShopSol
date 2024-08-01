

using System.ComponentModel.DataAnnotations;

namespace ShopSol.Aplication.Dto.Product
{
    public class ProductSaveDto : ProductBaseDto
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }
      
    }
}
