﻿using System.Linq.Expressions;

namespace Application.Interfaces.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllPredicateAsync(Expression<Func<T, bool>> predicate);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        bool DeleteAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task SaveChangesAsync();
        Task InsertRange(IEnumerable<T> entities);
    }
}
