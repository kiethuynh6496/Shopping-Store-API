using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities.ERP;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Shopping_Store_API.Commons.Constants;

namespace Shopping_Store_API.DTOs
{
    public class OrderItemDTO
    {
        public int OrderID { get; set; }
        public int ItemId { get; set; }
        public Product Item { get; set; }
        public int Quantity { get; set; }
    }
}