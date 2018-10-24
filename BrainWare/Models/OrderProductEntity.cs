using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("orderproduct")]
    public class OrderProductEntity
    {
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [ForeignKey("OrderId")]
        public virtual OrderEntity Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual  ProductEntity Product { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}