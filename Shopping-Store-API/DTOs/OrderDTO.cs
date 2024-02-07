using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities.ERP;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Shopping_Store_API.Commons.Constants;

namespace Shopping_Store_API.DTOs
{
    public class OrderDTO
    {
        public string UserId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public long Total { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}