namespace Shopping_Store_API.DTOs
{
    public class LogInResponseDTO
    {
        public string? UserId { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}