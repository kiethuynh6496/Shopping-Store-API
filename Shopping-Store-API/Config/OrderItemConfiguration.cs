using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(o => o.Order)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(o => o.OrderID);

            builder.HasOne(p => p.Item)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(si => si.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData
                (
                    new OrderItem
                    {
                        Id = 1,
                        OrderID = 1,
                        ItemId = 1,
                        Quantity = 3
                    },
                    new OrderItem
                    {
                        Id = 2,
                        OrderID = 1,
                        ItemId = 2,
                        Quantity = 3
                    },
                    new OrderItem
                    {
                        Id = 3,
                        OrderID = 1,
                        ItemId = 3,
                        Quantity = 3
                    },
                    new OrderItem
                    {
                        Id = 4,
                        OrderID = 2,
                        ItemId = 3,
                        Quantity = 3
                    },
                    new OrderItem
                    {
                        Id = 5,
                        OrderID = 3,
                        ItemId = 3,
                        Quantity = 3
                    },
                    new OrderItem
                    {
                        Id = 6,
                        OrderID = 4,
                        ItemId = 3,
                        Quantity = 3
                    }
                );
        }
    }
}
