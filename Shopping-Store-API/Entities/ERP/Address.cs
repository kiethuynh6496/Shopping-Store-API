using Shopping_Store_API.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    [Table("Address")]
    public class Address : EntityBase<int>
	{
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Addresses")]
        public virtual AppUser User { get; set; }

        public string? NickName { get; set; }
        public string? AddressName { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public bool? isDefault { get; set; } = false;
    }
}
