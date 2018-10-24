using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Dto
{
    public class Order
    {
        public int Order_Id { get; set; }
        public int OrderId { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public decimal OrderTotal { get; set; }

        public virtual IEnumerable<OrderProduct> OrderProducts { get; set; }

    }
}