using Shopping_Store_API.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    public class Product : AuditEntity<int>
    {
        public Product()
        {
            ProductShoppingCartItems = new HashSet<ShoppingCartItem>();
            OrderItems = new HashSet<OrderItem>();
        }

        public string Name { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public string? PictureUrl { get; set; }
        public int QuantityInStock { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey(nameof(CategoryID))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }

        public int BrandID { get; set; }
        [ForeignKey(nameof(BrandID))]
        [InverseProperty("Products")]
        public virtual Brand Brand { get; set; }

        public string? PublicIdCloudary { get; set; }

        [InverseProperty("Item")]
        public virtual ICollection<ShoppingCartItem> ProductShoppingCartItems { get; set; }

        [InverseProperty("Item")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
