using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.HasOne(s => s.ShoppingCart)
                .WithMany(si => si.ShoppingCartItems)
                .HasForeignKey(si => si.ShoppingCartID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Item)
                .WithMany(si => si.ProductShoppingCartItems)
                .HasForeignKey(si => si.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
