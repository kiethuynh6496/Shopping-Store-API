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
            builder.Property(t => t.CreatedBy)
                .HasDefaultValue("admin");
            builder.Property(t => t.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.HasOne(u => u.User)
                .WithMany(t => t.Tokens)
                .HasForeignKey(u => u.UserId);

            builder.HasData
                (
                    new Token
                    {
                        Id = 1,
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420",
                        IPAddress = "192.168.0.1",
                        UserAgent = "Chrome/91.0.4472.124",
                        RefreshToken = "",
                        ExpiresAt = DateTime.Now,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Token
                    {
                        Id = 2,
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420",
                        IPAddress = "192.168.0.2",
                        UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)",
                        RefreshToken = "",
                        ExpiresAt = DateTime.Now,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    },
                    new Token
                    {
                        Id = 3,
                        UserId = "94a12a30-1a9b-48ad-950d-29f80865003d",
                        IPAddress = "192.168.0.3",
                        UserAgent = "Safari/537.36",
                        RefreshToken = "",
                        ExpiresAt = DateTime.Now,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "admin",
                        UpdatedBy = "admin",
                    }
                );
        }
    }
}
