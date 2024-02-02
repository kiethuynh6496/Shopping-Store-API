using Shopping_Store_API.Base;
using Shopping_Store_API.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.Entities.ERP
{
    [Table("Token")]
    public class Token : AuditEntity<int>
    {
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Tokens")]
        public virtual AppUser User { get; set; }

        public string? IPAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
