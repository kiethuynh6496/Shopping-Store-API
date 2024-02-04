using Shopping_Store_API.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    [Table("ShoppingCartItem")]
    public class ShoppingCartItem : AuditEntity<int>
    {
        public int ShoppingCartID { get; set; }
        [ForeignKey(nameof(ShoppingCartID))]
        [InverseProperty("ShoppingCartItems")]
        public virtual ShoppingCart ShoppingCart { get; set; }

        public int ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        [InverseProperty("ProductShoppingCartItems")]
        public virtual Product Item { get; set; }

        public int Quantity { get; set; }
    }
}
