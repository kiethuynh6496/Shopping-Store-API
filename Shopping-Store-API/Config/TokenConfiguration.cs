using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(t => t.Tokens)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
