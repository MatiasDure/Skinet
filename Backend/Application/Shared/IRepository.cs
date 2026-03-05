using System;
using Core.Entities;
using Core.Specifications;

namespace Application;

public interface IRepository<T> where T : BaseEntity
{
        public void AddEntity(T entity);
        public Task<int> CountAsync(ISpecification<T> specification);
        public void DeleteEntity(T entity);
        public Task<IReadOnlyList<T>> GetListAsync();
        public Task<T?> GetEntityByIdAsync(int id);
        public Task<IReadOnlyList<T>> GetListWithSpecAsync(ISpecification<T> specification);
        public IQueryable<T> Query();
        public Task<bool> SaveChangesAsync();
}
