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
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.CreatedBy).HasDefaultValue("admin");
            builder.Property(t => t.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
