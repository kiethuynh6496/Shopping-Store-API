using Shopping_Store_API.Entities.ERP;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Store_API.DTOs
{
    public class LogInRequestDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}