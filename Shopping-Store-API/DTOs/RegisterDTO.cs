using System.ComponentModel.DataAnnotations;

namespace Shopping_Store_API.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }
}