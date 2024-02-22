﻿using Shopping_Store_API.DTOs.ProductDTOs;

namespace Shopping_Store_API.DTOs.OrderDTOs
{
    public class OrderItemDTO
    {
        public Guid OrderID { get; set; }
        public int ItemId { get; set; }
        public ProductDTO Item { get; set; }
        public int Quantity { get; set; }
    }
}