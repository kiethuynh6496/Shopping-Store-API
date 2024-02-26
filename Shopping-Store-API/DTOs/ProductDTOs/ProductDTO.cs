using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public int QuantityInStock { get; set; }
        public string PictureUrl { get; set; }

        public CategoryDTO Category { get; set; }
        public BrandDTO Brand { get; set; }
        public string? PublicIdCloudary { get; set; }
    }
}
