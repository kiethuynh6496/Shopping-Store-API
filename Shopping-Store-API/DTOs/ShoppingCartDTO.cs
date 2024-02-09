namespace Shopping_Store_API.DTOs
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<ShoppingCartItemDTO> ShoppingCartItems { get; set; }
    }
}
