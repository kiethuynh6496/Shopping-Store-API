using Shopping_Store_API.Base;
using System.Linq.Expressions;

namespace Shopping_Store_API.Interface.RepositoryInterface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> FindBy(Expression<Func<T, bool>> expression);
        Task<T> GetById(Expression<Func<T, bool>> expression);
        Task<bool> Add(T entity);
        bool Update(T entity);
        void Delete(T entity);
    }
}
