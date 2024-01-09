using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(t => t.CreatedBy)
                .HasDefaultValue("admin");
            builder.Property(t => t.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.HasData
                (
                    new Brand
                    {
                        Id = 1,
                        Name = "Dell",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Brand
                    {
                        Id = 2,
                        Name = "Apple",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Brand
                    {
                        Id = 3,
                        Name = "Gigabyte",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Brand
                    {
                        Id = 4,
                        Name = "Corsair",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Brand
                    {
                        Id = 5,
                        Name = "LG",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Brand
                    {
                        Id = 6,
                        Name = "Asus",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Brand
                    {
                        Id = 7,
                        Name = "Viewsonic",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Brand
                    {
                        Id = 8,
                        Name = "Acer",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    }
                );
        }
    }
}
