using Shopping_Store_API.Base;
using System.Linq.Expressions;

namespace Shopping_Store_API.Interface.RepositoryInterface
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetBy(Expression<Func<T, bool>> expression);
        Task<T> GetById(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
