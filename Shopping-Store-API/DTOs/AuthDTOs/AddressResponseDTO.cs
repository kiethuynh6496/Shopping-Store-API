namespace Shopping_Store_API.DTOs.AuthDTOs
{
    public class AddressResponseDTO
    {
        public int Id { get; set; }
        public string? NickName { get; set; }
        public string? Phone { get; set; }
        public string? AddressName { get; set; }
        public bool? isDefault { get; set; }
    }
}
