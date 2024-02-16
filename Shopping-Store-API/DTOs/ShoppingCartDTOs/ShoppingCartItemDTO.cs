using Shopping_Store_API.DTOs.ProductDTOs;

namespace Shopping_Store_API.DTOs.ShoppingCartDTOs
{
    public class ShoppingCartItemDTO
    {
        public int ItemId { get; set; }
        public ProductDTO Item { get; set; }
        public int Quantity { get; set; }
    }
}