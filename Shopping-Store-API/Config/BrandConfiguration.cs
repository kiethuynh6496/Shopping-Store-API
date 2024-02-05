using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData
                (
                    new Brand
                    {
                        Id = 1,
                        Name = "Dell"
                    },
                    new Brand
                    {
                        Id = 2,
                        Name = "Apple"
                    },
                    new Brand
                    {
                        Id = 3,
                        Name = "Gigabyte"
                    },
                    new Brand
                    {
                        Id = 4,
                        Name = "Corsair"
                    },
                    new Brand
                    {
                        Id = 5,
                        Name = "LG"
                    },
                    new Brand
                    {
                        Id = 6,
                        Name = "Asus"
                    },
                    new Brand
                    {
                        Id = 7,
                        Name = "Viewsonic"
                    },
                    new Brand
                    {
                        Id = 8,
                        Name = "Acer"
                    }
                );
        }
    }
}
