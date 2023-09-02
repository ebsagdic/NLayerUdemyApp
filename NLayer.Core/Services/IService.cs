using NLayer.Core.DTOs;
using System.Linq.Expressions;

namespace NLayer.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task <IEnumerable<T>> GetAllAsync();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsyc(Expression<Func<T, bool>> expression);

        Task<T> AddAsyc(T entity);

        Task<IEnumerable<T>> AddRangeAsyc(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);

        Task RemoveRangeAsync(IEnumerable<T> entities);
        Task GetByIdAsync();
        Task AddAsyc(ProductDto productDto);
    }
}
