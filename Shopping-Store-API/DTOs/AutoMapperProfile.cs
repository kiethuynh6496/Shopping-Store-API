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

            CreateMap<ShoppingCartDTO, ShoppingCart>()
                .ReverseMap();
            CreateMap<ShoppingCartItemDTO, ShoppingCartItem>()
                .ReverseMap();

            CreateMap<RegisterDTO, AppUser>()
                .ReverseMap();
            CreateMap<LogInResponseDTO, Token>()
                .ReverseMap();

            CreateMap<OrderDTO, Order>()
                .ReverseMap();
            CreateMap<OrderItemDTO, OrderItem>()
                .ReverseMap();
        }
    }
}
