using ShopSol.Common.Data.Base;

using System.ComponentModel.DataAnnotations.Schema;


namespace ShopSol.Persistence.DbObject
{
    public class SuppliersDb : AudityEntity <int>
    {
        [Column("supplierid")]
        public override int Id { get; set; }
    }
}
