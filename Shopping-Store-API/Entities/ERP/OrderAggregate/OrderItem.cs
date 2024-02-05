using Shopping_Store_API.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    [Table("OrderItem")]
    public class OrderItem : AuditEntity<int>
    {
        public int OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        [InverseProperty("OrderItems")]
        public virtual Order Order { get; set; }

        public int ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        [InverseProperty("OrderItems")]
        public virtual Product Item { get; set; }

        public int Quantity { get; set; }
    }
}
