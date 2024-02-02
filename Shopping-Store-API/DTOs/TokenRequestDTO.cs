using Shopping_Store_API.Entities.ERP;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.DTOs
{
    public class TokenRequestDTO
    {
        public string? RefreshToken { get; set; } = string.Empty;
    }
}