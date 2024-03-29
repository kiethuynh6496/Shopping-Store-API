﻿using Shopping_Store_API.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    [Table("ShoppingCart")]
    public class ShoppingCart : EntityBase<int>
    {
        public ShoppingCart()
        {
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("ShoppingCart")]
        public AppUser User { get; set; }

        [InverseProperty(nameof(ShoppingCartItem.ShoppingCart))]
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }

        public string? PaymentIntenId { get; set; }
        public string? ClientSecret { get; set; }

        public void AddItem(Product product, int quantity)
        {
            var newItem = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                QuantityInStock = product.QuantityInStock,
                CategoryID = product.CategoryID,
                BrandID = product.BrandID,
                PublicIdCloudary = product.PublicIdCloudary,
            };
            if(ShoppingCartItems.All(item => item.ItemId != product.Id))
            {
                ShoppingCartItems.Add(new ShoppingCartItem { ItemId = product.Id, Quantity = quantity, Item = newItem });
                return;
            }

            var existingItem = ShoppingCartItems.FirstOrDefault(item => item.ItemId.Equals(product.Id));
            if(existingItem != null)
            {
                if (existingItem.Quantity == 0 && existingItem.IsDeleted)
                {
                    existingItem.IsDeleted = false;
                }
                existingItem.Quantity += quantity;
            }
        }

        public void RemoveItem(int productId, int quantity)
        {
            var item = ShoppingCartItems.FirstOrDefault(item => item.ItemId == productId);
            if (item == null) return;
            if(item.IsDeleted) return;
            item.Quantity = item.Quantity - quantity <= 0 ? 0 : item.Quantity - quantity;
            if(item.Quantity == 0)
            {
                ShoppingCartItems.Remove(item);
            }
        }
    }
}