    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSol.Aplication.Dto.Supplier
{
    public class SupplierDto
    {
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }
        public DateTime? modify_date { get; set; }
        public int? ModifyUser { get; set; }
    }
}
