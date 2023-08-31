using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsyc (Expression<Func<T, bool>> expression);

        Task AddAsyc (T entity);

        Task AddRangeAsyc (IEnumerable<T> entities);

        void Update (T entity);

        void Remove (T entity);

        void RemoveRange (IEnumerable<T> entities);




    }
}
