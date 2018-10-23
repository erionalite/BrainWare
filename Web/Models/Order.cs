using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        public int OrderId { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public decimal OrderTotal { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }

    }
}