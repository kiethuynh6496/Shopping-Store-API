using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
                (
                    new Category
                    {
                        Id = 1,
                        Name = "Laptop"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Ipad"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Screen"
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Iphone"
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Macbook"
                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Mainboard"
                    },
                    new Category
                    {
                        Id = 7,
                        Name = "Case"
                    }
                );
        }
    }
}
