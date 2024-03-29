﻿using Shopping_Store_API.Base;
using System.ComponentModel.DataAnnotations.Schema;
using static Shopping_Store_API.Commons.Constants;

namespace Shopping_Store_API.Entities.ERP
{
    [Table("Order")]
    public class Order : AuditEntity<Guid>
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Orders")]
        public virtual AppUser User { get; set; }

        [InverseProperty(nameof(OrderItem.Order))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public string? NickName { get; set; }
        public string? AddressName { get; set; }
        public string? Phone { get; set; }
        public long Total { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string? PaymentIntenId { get; set; }
        public string? MomoRequestId { get; set; }
    }
}
