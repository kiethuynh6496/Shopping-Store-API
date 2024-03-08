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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/jqyuena1vpsuojaht4vu.png",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/n28l0eh9rjx2bihtxoy5.jpg",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/hpgz7xlaqa52xo7ubjw9.png",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/enebiqezhcup3lgkcstb.png",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/gpomm9nf5w3w4juiooiv.png",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/yysgxkbqiufbui1hb9si.jpg",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/wsb51zjp5mc4wqbfxatp.png",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/teghmyo3k3hdkau9qne7.png",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/i39drgkscnglo4qh6tvr.jpg",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/iwoww4fcebhsximqr2e7.jpg",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/bsca35kdtcrrsrahalrb.jpg",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/eiwqbjg53c1iiyfyuubx.png",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/vhxrw4q797mox11xllpf.png",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/jxdj5mfcy47ee0bwfmnp.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/iilp2mh1066ifpxiluur.png",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/x8nbir1cb3vymmubj0qd.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/kvk93lqt9iyjfnbhf39u.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/k5uu8rmgex2g8nr45ldi.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/v01sbaf9rbkzw8yhtdwv.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/njtxjkkamuulhb4alvdg.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/jhxgm22du9zgbe2sw5zc.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/lrjtodqgvmojr94durpt.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/tihrkueyfuawaaob6f0g.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/timgmpaw7v0i9gpx0ayv.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/tmjzsdvpgixl7dedthkm.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/ncpg1p2grvu9mbj66gh4.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693476/shopee/products/qmauhpz1jych8vf6g2hb.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/qamr31r8gxd9rfcxkaiw.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693475/shopee/products/gwt4kwqllyybkrwofd1m.webp",
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
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693475/shopee/products/feqpxb8w3aw97cwq3d8v.webp",
                        BrandID = 6,
                        CategoryID = 3,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 31,
                        Name = "Dell Latitude 7320 - 2",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 1000,
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/jqyuena1vpsuojaht4vu.png",
                        BrandID = 1,
                        CategoryID = 1,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 32,
                        Name = "Dell Latitude 7330 - 2",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 2000,
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/n28l0eh9rjx2bihtxoy5.jpg",
                        BrandID = 1,
                        CategoryID = 1,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 33,
                        Name = "Dell Inspiron 6430 - 2",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 3000,
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/hpgz7xlaqa52xo7ubjw9.png",
                        BrandID = 1,
                        CategoryID = 1,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 34,
                        Name = "Dell Inspiron 6530 - 2",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 4000,
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/enebiqezhcup3lgkcstb.png",
                        BrandID = 1,
                        CategoryID = 1,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 35,
                        Name = "Ipad M1 12.9 - 2",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 5000,
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/gpomm9nf5w3w4juiooiv.png",
                        BrandID = 2,
                        CategoryID = 2,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 36,
                        Name = "Ipad M1 12.9 - 3",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 6000,
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/yysgxkbqiufbui1hb9si.jpg",
                        BrandID = 2,
                        CategoryID = 2,
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Id = 37,
                        Name = "Dell Screen 27inch - 2",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 7000,
                        PictureUrl = "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/wsb51zjp5mc4wqbfxatp.png",
                        BrandID = 1,
                        CategoryID = 3,
                        QuantityInStock = 100
                    }
                );
        }
    }
}
