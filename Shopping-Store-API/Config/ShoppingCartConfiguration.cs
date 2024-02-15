using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasData
                (
                    new ShoppingCart
                    {
                        Id = 1,
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420"
                    }
                );
        }
    }
}
