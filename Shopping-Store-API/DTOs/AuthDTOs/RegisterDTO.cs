using System.ComponentModel.DataAnnotations;

namespace Shopping_Store_API.DTOs.AuthDTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}