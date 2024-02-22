using static Shopping_Store_API.Commons.Constants;

namespace Shopping_Store_API.DTOs.OrderDTOs
{
    public class OrderResponseDTO
    {
        public string UserId { get; set; }

        public ICollection<OrderItemDTO> OrderItems { get; set; }

        public long Total { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PaymentIntenId { get; set; }
        public string MomoRequestId { get; set; }
    }
}