    
using System.ComponentModel.DataAnnotations;

namespace ShopSol.Aplication.Dto.Product
{
    public class ProductRemoveDto : ProductBaseDto
    {
   
        public int delete_user { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime delete_date { get; set; }
        public bool deleted { get; set; }
    }
}
