using Shopping_Store_API.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    [Table("Category")]
    public class Category : AuditEntity<int>
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public string Name { get; set; }
        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
