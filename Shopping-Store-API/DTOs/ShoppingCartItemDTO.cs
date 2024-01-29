using Shopping_Store_API.Entities.ERP;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.DTOs
{
    public class ShoppingCartItemDTO
    {
        public int ItemId { get; set; }
        public ProductDTO Item { get; set; }
        public int Quantity { get; set; }
    }
}