using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Tokens = new HashSet<Token>();
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
        }

        [MaxLength(100)]
        public string? FullName { set; get; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }

        [InverseProperty("User")]
        public virtual ShoppingCart ShoppingCart { get; set; }

        [InverseProperty(nameof(Token.User))]
        public virtual ICollection<Token> Tokens { get; set; }

        [InverseProperty(nameof(Address.User))]
        public virtual ICollection<Address> Addresses { get; set; }

        [InverseProperty(nameof(Order.User))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
