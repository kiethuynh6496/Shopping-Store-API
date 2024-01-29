using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Shopping_Store_API.DBContext;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.RepositoryInterface;
using System.Linq.Expressions;

namespace Shopping_Store_API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbFactory _dbFactory;
        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }

        public GenericRepository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return await DbSet.FindAsync(expression);
        }

        public async Task<T> GetById(Expression<Func<T, bool>> expression)
        {
            var product = await DbSet.FirstOrDefaultAsync(expression);
            return product;
        }

        public async Task<bool> Add(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).CreatedDate = DateTime.UtcNow;
            }
            await DbSet.AddAsync(entity);
            return true;
        }

        public bool Update(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).UpdatedDate = DateTime.UtcNow;
            }
            DbSet.Update(entity);
            return true;
        }

        public void Delete(T entity)
        {
            if (typeof(IDeleteEntity).IsAssignableFrom(typeof(T)))
            {
                ((IDeleteEntity)entity).IsDeleted = true;
                DbSet.Update(entity);
            }
            else
                DbSet.Remove(entity);
        }
    }
}