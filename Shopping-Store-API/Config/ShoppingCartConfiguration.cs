using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.Property(t => t.CreatedBy)
                .HasDefaultValue("admin");
            builder.Property(t => t.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.HasData
                (
                    new ShoppingCart
                    {
                        Id = 1,
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420"
                    },
                    new ShoppingCart
                    {
                        Id = 2,
                        UserId = "94a12a30-1a9b-48ad-950d-29f80865003d"
                    },
                    new ShoppingCart
                    {
                        Id = 3,
                        UserId = "f222bfbf-86bf-4b65-9958-bc818ba5f822"
                    }
                );
        }
    }
}
