using AutoMapper;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ReverseMap();
            CreateMap<CategoryDTO, Category>()
                .ReverseMap();
            CreateMap<BrandDTO, Brand>()
                .ReverseMap();
        }
    }
}
