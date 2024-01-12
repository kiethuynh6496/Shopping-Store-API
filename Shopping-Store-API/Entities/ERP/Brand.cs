using Shopping_Store_API.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    [Table("Brand")]
    public class Brand : AuditEntity<int>
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public string Name { get; set; }
        [InverseProperty(nameof(Product.Brand))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
