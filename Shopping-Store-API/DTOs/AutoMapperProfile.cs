using AutoMapper;
using Shopping_Store_API.DTOs.AuthDTOs;
using Shopping_Store_API.DTOs.OrderDTOs;
using Shopping_Store_API.DTOs.ProductDTOs;
using Shopping_Store_API.DTOs.ShoppingCartDTOs;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ReverseMap();
            CreateMap<CreateProductResponseDTO, Product>()
                .ReverseMap();
            CreateMap<CategoryDTO, Category>()
                .ReverseMap();
            CreateMap<BrandDTO, Brand>()
                .ReverseMap();

            CreateMap<ShoppingCartDTO, ShoppingCart>()
                .ReverseMap();
            CreateMap<ShoppingCartItemDTO, ShoppingCartItem>()
                .ReverseMap();

            CreateMap<UserDTO, AppUser>()
                .ReverseMap();
            CreateMap<AddressResponseDTO, Address>()
                .ReverseMap();
            CreateMap<RegisterDTO, AppUser>()
                .ReverseMap();
            CreateMap<LogInResponseDTO, Token>()
                .ReverseMap();

            CreateMap<OrderItemDTO, OrderItem>()
                .ReverseMap();
            CreateMap<OrderResponseDTO, Order>()
                .ReverseMap();

        }
    }
}
