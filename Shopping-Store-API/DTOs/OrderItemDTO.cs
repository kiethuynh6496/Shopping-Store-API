using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.DTOs
{
    public class OrderItemDTO
    {
        public int OrderID { get; set; }
        public int ItemId { get; set; }
        public ProductDTO Item { get; set; }
        public int Quantity { get; set; }
    }
}