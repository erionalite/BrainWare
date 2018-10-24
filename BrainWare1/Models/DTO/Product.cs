using System.ComponentModel.DataAnnotations;

namespace Web.Models.Dto
{
    public class Product
    {
        public int Product_Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}