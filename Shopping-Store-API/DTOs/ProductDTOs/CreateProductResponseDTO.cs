using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.DTOs.ProductDTOs
{
    public class CreateProductResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public int QuantityInStock { get; set; }

        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public string? PublicIdCloudary { get; set; }
    }
}
