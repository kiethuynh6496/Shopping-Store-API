namespace Shopping_Store_API.DTOs.AuthDTOs
{
    public class UserDTO
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Birthday { get; set; }
        public string? PhoneNumber { get; set;}
        public List<AddressResponseDTO> Addresses { get; set; }
    }
}