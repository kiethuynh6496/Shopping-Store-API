using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Config
{
	public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(a => a.Addresses)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData
                (
                    new Address
                    {
                        Id = 1,
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420",
                        NickName = "Huynh Tuan Kiet",
                        AddressName = "172/26 Ly Thai To, Q.3",
                        Phone = "0386226362",
                        City = "HCM",
                        isDefault = true
                    },
                    new Address
                    {
                        Id = 2,
                        UserId = "d68dcb5f-2706-4cb5-bb0b-37bf39400420",
                        NickName = "Au Duong Phong",
                        AddressName = "175 Duong so 1, Go Vap",
                        Phone = "0129629521",
                        City = "HCM",
                        isDefault = false
                    }
                );
        }
    }
}
