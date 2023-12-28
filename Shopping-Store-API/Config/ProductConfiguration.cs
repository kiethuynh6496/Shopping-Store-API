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
            builder.Property(t => t.CreatedBy)
                .HasDefaultValue("admin");
            builder.Property(t => t.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.HasData
                (
                new Product
                {
                    Id = 1,
                    Name = "Dell Latitude 7320",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-01.png",
                    Brand = "Dell",
                    Type = "Laptop",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 2,
                    Name = "Dell Latitude 7330",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-02.png",
                    Brand = "Dell",
                    Type = "Laptop",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 3,
                    Name = "Dell Inspiron 6430",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-03.png",
                    Brand = "Dell",
                    Type = "Laptop",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 4,
                    Name = "Dell Inspiron 6530",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-04.png",
                    Brand = "Dell",
                    Type = "Laptop",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 5,
                    Name = "Ipad M1 12.9",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-05.png",
                    Brand = "Apple",
                    Type = "Ipad",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 6,
                    Name = "Ipad M1 12.9",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-06.png",
                    Brand = "Apple",
                    Type = "Ipad",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 7,
                    Name = "Dell Screen 27inch",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-07.png",
                    Brand = "Dell",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 8,
                    Name = "Dell Screen 27inch",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-08.png",
                    Brand = "Dell",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 9,
                    Name = "Iphone 14 Pro Max",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-09.jpeg",
                    Brand = "Apple",
                    Type = "Iphone",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 10,
                    Name = "Iphone 14 Pro Max",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-10.jpeg",
                    Brand = "Apple",
                    Type = "Iphone",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 11,
                    Name = "Macbook Air M1",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-11.jpeg",
                    Brand = "Apple",
                    Type = "Macbook",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 12,
                    Name = "Macbook Air M1",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-12.png",
                    Brand = "Apple",
                    Type = "Macbook",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 13,
                    Name = "Mainboard Gigabyte 6330",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-13.png",
                    Brand = "Gigabyte",
                    Type = "Mainboard",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 14,
                    Name = "Mainboard Gigabyte 6330",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-14.png",
                    Brand = "Gigabyte",
                    Type = "Mainboard",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 15,
                    Name = "Case Corsair",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-15.png",
                    Brand = "Corsair",
                    Type = "Case",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 16,
                    Name = "LG Ultra Gear",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-16.png",
                    Brand = "LG",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 17,
                    Name = "LG Ultra Gear",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-17.png",
                    Brand = "LG",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 18,
                    Name = "MSI 27",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-18.png",
                    Brand = "Asus",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 19,
                    Name = "Viewsonic 24",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-19.png",
                    Brand = "Viewsonic",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 20,
                    Name = "Acer 27",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-20.png",
                    Brand = "Acer",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 21,
                    Name = "Asus 27 Freesync",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-21.png",
                    Brand = "Asus",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 22,
                    Name = "Asus 24 Freesync",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-22.png",
                    Brand = "Asus",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 23,
                    Name = "Viewsonic 24 Freesync",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-23.png",
                    Brand = "Viewsonic",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 24,
                    Name = "Viewsonic 24 Freesync 75Hz",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-24.png",
                    Brand = "Viewsonic",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 25,
                    Name = "Asus TUF Gaming 24",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-25.png",
                    Brand = "Asus",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 26,
                    Name = "Gigabyte 24",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-26.png",
                    Brand = "Gigabyte",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 27,
                    Name = "Asus GM27",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-27.png",
                    Brand = "Asus",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 28,
                    Name = "Acer 75hz 27",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-28.png",
                    Brand = "Acer",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 29,
                    Name = "LG 75hz 27",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-29.png",
                    Brand = "LG",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                },
                new Product
                {
                    Id = 30,
                    Name = "Asus 100hz 27",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/product-30.png",
                    Brand = "Asus",
                    Type = "Screen",
                    QuantityInStock = 100,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin",
                }
                );
        }
    }
}
