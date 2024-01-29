using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(u => u.ShoppingCart)
                .WithOne(s => s.User)
                .HasForeignKey<ShoppingCart>(s => s.UserId);

            builder.HasData
                (
                    new AppUser
                    {
                        Id = "d68dcb5f-2706-4cb5-bb0b-37bf39400420",
                        FullName = "kiethuynh",
                        Address = "TP Ho Chi Minh",
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        AccessFailedCount= 0
                    },
                    new AppUser
                    {
                        Id = "94a12a30-1a9b-48ad-950d-29f80865003d",
                        FullName = "mangoc",
                        Address = "TP Ho Chi Minh",
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0
                    },
                    new AppUser
                    {
                        Id = "f222bfbf-86bf-4b65-9958-bc818ba5f822",
                        FullName = "auduongphong",
                        Address = "TP Ho Chi Minh",
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0
                    }
                );
        }
    }
}
