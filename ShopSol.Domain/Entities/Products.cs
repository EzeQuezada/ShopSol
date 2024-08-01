
using ShopSol.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopMonolitica.Web.Data.Entities
{
    [Table("Products", Schema = "Production")]
    public class Products : AudityEntity<int>
    {
        [Key]
        [Column("productid")]
        public override int Id { get; set; }
        public string? productname { get; set; }
        public double unitprice { get; set; }
        public bool discontinued { get; set; }

    }
}  
