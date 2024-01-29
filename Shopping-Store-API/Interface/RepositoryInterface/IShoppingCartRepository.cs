using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Service.Parameters;

namespace Shopping_Store_API.Interface.RepositoryInterface
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
        Task<ShoppingCart> GetShoppingCart(string userId, bool IsTracked);
        ShoppingCart CreateShoppingCart(string userId, HttpResponse httpResponse);
    }
}
