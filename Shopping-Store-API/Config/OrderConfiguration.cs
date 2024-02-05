using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(u => u.UserId);

            builder.HasData
                (
                    new Order
                    {
                        Id = 1,
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420",
                        Total = 100000
                    },
                    new Order
                    {
                        Id = 2,
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420",
                        Total = 110000
                    },
                    new Order
                    {
                        Id = 3,
                        UserId = "94a12a30-1a9b-48ad-950d-29f80865003d",
                        Total = 120000
                    },
                    new Order
                    {
                        Id = 4,
                        UserId = "f222bfbf-86bf-4b65-9958-bc818ba5f822",
                        Total = 130000
                    }
                );
        }
    }
}
