using Shopping_Store_API.Interface.RepositoryInterface;

namespace Shopping_Store_API.Interface
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        Task<int> CommitAsync();
    }
}
