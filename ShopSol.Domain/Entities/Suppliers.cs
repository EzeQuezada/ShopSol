
using ShopSol.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMonolitica.Web.Data.Entities
{
    public class Suppliers : AudityEntity<int>
    {
        [Column ("supplierid")]
        public override int Id { get; set; }
        public int supplierid { get; set; }


    }

}
