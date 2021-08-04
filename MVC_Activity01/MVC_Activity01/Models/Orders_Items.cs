using System.ComponentModel.DataAnnotations;

namespace MVC_Activity01.Models
{
    public class Orders_Items
    {
       [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}