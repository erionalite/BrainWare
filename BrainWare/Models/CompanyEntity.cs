using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Company")]
    public class CompanyEntity
    {
        [Key]
        public int company_id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}