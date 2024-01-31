using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.HasData
                (
                    new IdentityUserClaim<string>
                    {
                        Id = 1,
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420",
                        ClaimType = "Country",
                        ClaimValue = "VN"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 2,
                        UserId = "94a12a30-1a9b-48ad-950d-29f80865003d",
                        ClaimType = "Country",
                        ClaimValue = "VN"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 3,
                        UserId = "f222bfbf-86bf-4b65-9958-bc818ba5f822",
                        ClaimType = "Country",
                        ClaimValue = "USA"
                    }
                );
        }
    }
}
