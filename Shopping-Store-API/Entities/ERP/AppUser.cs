using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Tokens = new List<Token>();
        }

        [MaxLength(100)]
        public string? FullName { set; get; }

        [MaxLength(255)]
        public string? Address { set; get; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }

        [InverseProperty("User")]
        public virtual ShoppingCart ShoppingCart { get; set; }

        [InverseProperty(nameof(Token.User))]
        public virtual List<Token> Tokens { get; set; }
    }
}
