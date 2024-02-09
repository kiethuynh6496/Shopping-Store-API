using Shopping_Store_API.Base;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping_Store_API.Interface.RepositoryInterface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> FindById(Expression<Func<T, bool>> expression, bool IsTracked = false);
        IQueryable<T> FindByAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<bool> Add(T entity);
        bool Update(T entity);
        void Delete(T entity);
    }
}
