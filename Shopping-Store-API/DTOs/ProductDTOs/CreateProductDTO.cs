using System.ComponentModel.DataAnnotations;

namespace Shopping_Store_API.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(100, Double.PositiveInfinity)]
        public long Price { get; set; }
        //public IFormFile PictureUrl { get; set; }
        [Required]
        [Range(0, 200)]
        public int QuantityInStock { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Brand { get; set; }
    }
}
