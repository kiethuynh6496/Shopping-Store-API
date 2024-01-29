using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Service.Parameters;

namespace Shopping_Store_API.Interface.ServiceInterface
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetShoppingCart(string userId, bool IsTracked);

        Task<bool> AddItemToShoppingCart(string userId, ShoppingCartParameters shoppingCartParameters, HttpResponse httpResponse);

        Task<bool> RemoveItemToShoppingCart(string userId, ShoppingCartParameters shoppingCartParameters);
    }
}