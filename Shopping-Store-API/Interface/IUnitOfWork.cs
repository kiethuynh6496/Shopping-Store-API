using Shopping_Store_API.Interface.RepositoryInterface;

namespace Shopping_Store_API.Interface
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        IShoppingCartRepository ShoppingCart { get; }

        IShoppingCartItemRepository ShoppingCartItem { get; }

        Task<int> CommitAsync();

        void Modify<TEntity>(TEntity entity) where TEntity : class;
    }
}
