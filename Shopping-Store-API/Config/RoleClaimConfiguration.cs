using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
        {
            builder.HasData
                (
                    new IdentityRoleClaim<string>
                    {
                        Id = 1,
                        RoleId = "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9",
                        ClaimType = "Permission",
                        ClaimValue = "CanManageUsers"
                    },
                    new IdentityRoleClaim<string>
                    {
                        Id = 2,
                        RoleId = "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9",
                        ClaimType = "Permission",
                        ClaimValue = "CanManageProducts"
                    },
                    new IdentityRoleClaim<string>
                    {
                        Id = 3,
                        RoleId = "4d267d01-3ce5-44d4-bf99-a3fd2172ba17",
                        ClaimType = "Permission",
                        ClaimValue = "CanViewProducts"
                    }
                );
        }
    }
}
