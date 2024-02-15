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
        }
    }
}
