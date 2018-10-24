using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Product")]
    public class ProductEntity
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public virtual ICollection<OrderProductEntity> OrdersForProduct { get; set; }
    }
}