using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.Property(t => t.CreatedBy)
                .HasDefaultValue("admin");
            builder.Property(t => t.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.HasOne(s => s.ShoppingCart)
                .WithMany(si => si.ShoppingCartItems)
                .HasForeignKey(si => si.ShoppingCartID);

            builder.HasOne(p => p.Item)
                .WithMany(si => si.ProductShoppingCartItems)
                .HasForeignKey(si => si.ItemId);

            builder.HasData
                (
                    new ShoppingCartItem
                    {
                        Id = 1,
                        ShoppingCartID = 1,
                        ItemId = 1,
                        Quantity = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new ShoppingCartItem
                    {
                        Id = 2,
                        ShoppingCartID = 1,
                        ItemId = 2,
                        Quantity = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new ShoppingCartItem
                    {
                        Id = 3,
                        ShoppingCartID = 1,
                        ItemId = 3,
                        Quantity = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new ShoppingCartItem
                    {
                        Id = 4,
                        ShoppingCartID = 2,
                        ItemId = 1,
                        Quantity = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new ShoppingCartItem
                    {
                        Id = 5,
                        ShoppingCartID = 2,
                        ItemId = 2,
                        Quantity = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new ShoppingCartItem
                    {
                        Id = 6,
                        ShoppingCartID = 2,
                        ItemId = 3,
                        Quantity = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new ShoppingCartItem
                    {
                        Id = 7,
                        ShoppingCartID = 3,
                        ItemId = 1,
                        Quantity = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new ShoppingCartItem
                    {
                        Id = 8,
                        ShoppingCartID = 3,
                        ItemId = 2,
                        Quantity = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new ShoppingCartItem
                    {
                        Id = 9,
                        ShoppingCartID = 3,
                        ItemId = 3,
                        Quantity = 3,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    }
                );
        }
    }
}
