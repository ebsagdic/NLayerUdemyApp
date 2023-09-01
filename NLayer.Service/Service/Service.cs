using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System.Linq.Expressions;

namespace NLayer.Service.Service
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        public Service(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
        {
            _repository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsyc(T entity)
        {
            await _repository.AddAsyc(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsyc(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsyc(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsyc(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsyc(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);   
        }
    }
}
