using static Shopping_Store_API.Commons.Constants;

namespace Shopping_Store_API.DTOs
{
    public class OrderResponseDTO
    {
        public string UserId { get; set; }

        public ICollection<OrderItemDTO> OrderItems { get; set; }

        public long Total { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public DateTime CreatedDate { get; set; }
    }
}