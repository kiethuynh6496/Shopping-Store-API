using Shopping_Store_API.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    public class Product : AuditEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public string? PictureUrl { get; set; }
        public int QuantityInStock { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey(nameof(CategoryID))]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(BrandID))]
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
