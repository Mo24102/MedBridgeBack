using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedBridge.Models.ProductModels;

namespace MedBridge.Models.OrderModels
{
    public enum OrderStatus
    {
        Pending,
        Approved,
        Rejected,
        Cancelled
    }
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public ICollection<OrderItem>? OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
