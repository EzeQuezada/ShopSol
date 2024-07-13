
using ShopSol.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopMonolitica.Web.Data.Entities
{ 
    public class Products : AudityEntity<int>
    {
        [Column("productId")]
        public override int Id { get; set; }
        public int productid { get; set; }
        public string? productname { get; set; }
        public double unitprice { get; set; }
        public bool discontinued { get; set; }

    }
}  
