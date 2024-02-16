namespace Shopping_Store_API.DTOs.ShoppingCartDTOs
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<ShoppingCartItemDTO> ShoppingCartItems { get; set; }
        public string PaymentIntenId { get; set; }
        public string ClientSecret { get; set; }
    }
}
