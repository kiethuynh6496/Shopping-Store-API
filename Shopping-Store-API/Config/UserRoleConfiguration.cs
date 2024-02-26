using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping_Store_API.Config
{
	public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData
                (
                    new IdentityUserRole<string>
                    {
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420",
                        RoleId = "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9"
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420",
                        RoleId = "4d267d01-3ce5-44d4-bf99-a3fd2172ba17"
                    }
                );
        }
    }
}
