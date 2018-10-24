using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Order")]
    public class OrderEntity
    {
        [Key]
        public int Order_Id { get; set; }

        public string Description { get; set; }

        [Column("company_id")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual CompanyEntity CompanyEntity { get; set; }

        public virtual ICollection<OrderProductEntity> OrderProducts { get; set; }
    }
}