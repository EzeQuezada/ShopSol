
using ShopSol.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMonolitica.Web.Data.Entities
{
    
    public class Suppliers : AudityEntity<int>
    {
        
        [Column ("supplierid")]
        public override int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }





    }

}
