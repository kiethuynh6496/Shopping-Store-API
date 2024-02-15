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
                        UserName = "admin@gmail.com",
                        Email = "admin@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAEORqsu30Xu2m4FyF5WRg8ScZ6GZOtWBBeEVNO3Hgfq03k/bjHmUAKOh0SWJRkMjVdA==",
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        AccessFailedCount= 0
                    }
                );
        }
    }
}
