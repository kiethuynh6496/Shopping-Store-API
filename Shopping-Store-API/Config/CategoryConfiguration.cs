using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(t => t.CreatedBy)
                .HasDefaultValue("admin");
            builder.Property(t => t.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.HasData
                (
                    new Category
                    {
                        Id = 1,
                        Name = "Laptop",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Ipad",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Screen",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Iphone",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Macbook",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Mainboard",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Category
                    {
                        Id = 7,
                        Name = "Case",
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    }
                );
        }
    }
}
