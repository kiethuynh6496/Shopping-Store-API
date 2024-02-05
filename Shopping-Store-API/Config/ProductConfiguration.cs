using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(t => t.Name)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID);

            builder.HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandID);

            builder.HasData
                (
                    new Product
                    {
                        Id = 1,
                        Name = "Dell Latitude 7320",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 1000,
                        PictureUrl = "/images/products/product-01.png",
                        BrandID = 1,
                        CategoryID = 1,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Dell Latitude 7330",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 2000,
                        PictureUrl = "/images/products/product-02.png",
                        BrandID = 1,
                        CategoryID = 1,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Dell Inspiron 6430",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 3000,
                        PictureUrl = "/images/products/product-03.png",
                        BrandID = 1,
                        CategoryID = 1,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Dell Inspiron 6530",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 4000,
                        PictureUrl = "/images/products/product-04.png",
                        BrandID = 1,
                        CategoryID = 1,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Ipad M1 12.9",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 5000,
                        PictureUrl = "/images/products/product-05.png",
                        BrandID = 2,
                        CategoryID = 2,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Ipad M1 12.9",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 6000,
                        PictureUrl = "/images/products/product-06.png",
                        BrandID = 2,
                        CategoryID = 2,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "Dell Screen 27inch",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 7000,
                        PictureUrl = "/images/products/product-07.png",
                        BrandID = 1,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "Dell Screen 27inch",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 8000,
                        PictureUrl = "/images/products/product-08.png",
                        BrandID = 1,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 9,
                        Name = "Iphone 14 Pro Max",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 9000,
                        PictureUrl = "/images/products/product-09.jpeg",
                        BrandID = 2,
                        CategoryID = 4,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 10,
                        Name = "Iphone 14 Pro Max",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 10000,
                        PictureUrl = "/images/products/product-10.jpeg",
                        BrandID = 2,
                        CategoryID = 4,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 11,
                        Name = "Macbook Air M1",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 11000,
                        PictureUrl = "/images/products/product-11.jpeg",
                        BrandID = 2,
                        CategoryID = 5,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 12,
                        Name = "Macbook Air M1",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 12000,
                        PictureUrl = "/images/products/product-12.png",
                        BrandID = 2,
                        CategoryID = 5,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 13,
                        Name = "Mainboard Gigabyte 6330",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 13000,
                        PictureUrl = "/images/products/product-13.png",
                        BrandID = 3,
                        CategoryID = 6,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 14,
                        Name = "Mainboard Gigabyte 6330",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 14000,
                        PictureUrl = "/images/products/product-14.png",
                        BrandID = 3,
                        CategoryID = 6,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 15,
                        Name = "Case Corsair",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 15000,
                        PictureUrl = "/images/products/product-15.png",
                        BrandID = 4,
                        CategoryID = 7,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 16,
                        Name = "LG Ultra Gear",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 16000,
                        PictureUrl = "/images/products/product-16.png",
                        BrandID = 5,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 17,
                        Name = "LG Ultra Gear",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 17000,
                        PictureUrl = "/images/products/product-17.png",
                        BrandID = 5,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 18,
                        Name = "MSI 27",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 18000,
                        PictureUrl = "/images/products/product-18.png",
                        BrandID = 6,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 19,
                        Name = "Viewsonic 24",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 19000,
                        PictureUrl = "/images/products/product-19.png",
                        BrandID = 7,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 20,
                        Name = "Acer 27",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 10000,
                        PictureUrl = "/images/products/product-20.png",
                        BrandID = 8,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 21,
                        Name = "Asus 27 Freesync",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 21000,
                        PictureUrl = "/images/products/product-21.png",
                        BrandID = 6,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 22,
                        Name = "Asus 24 Freesync",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 22000,
                        PictureUrl = "/images/products/product-22.png",
                        BrandID = 6,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 23,
                        Name = "Viewsonic 24 Freesync",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 23000,
                        PictureUrl = "/images/products/product-23.png",
                        BrandID = 7,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 24,
                        Name = "Viewsonic 24 Freesync 75Hz",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 24000,
                        PictureUrl = "/images/products/product-24.png",
                        BrandID = 7,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 25,
                        Name = "Asus TUF Gaming 24",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 25000,
                        PictureUrl = "/images/products/product-25.png",
                        BrandID = 6,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 26,
                        Name = "Gigabyte 24",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 26000,
                        PictureUrl = "/images/products/product-26.png",
                        BrandID = 3,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 27,
                        Name = "Asus GM27",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 27000,
                        PictureUrl = "/images/products/product-27.png",
                        BrandID = 6,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 28,
                        Name = "Acer 75hz 27",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 28000,
                        PictureUrl = "/images/products/product-28.png",
                        BrandID = 8,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 29,
                        Name = "LG 75hz 27",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 29000,
                        PictureUrl = "/images/products/product-29.png",
                        BrandID = 5,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 30,
                        Name = "Asus 100hz 27",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 30000,
                        PictureUrl = "/images/products/product-30.png",
                        BrandID = 6,
                        CategoryID = 3,
                        QuantityInStock = 100
                    }
                );
        }
    }
}
