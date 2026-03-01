using System;
using Core.Entities;
using Core.Specifications;

namespace Application;

public interface IRepository<T> where T : BaseEntity
{
        public Task<T?> GetEntityByIdAsync(int id);
        public Task<IReadOnlyList<T>> GetListAsync();
        public void AddEntity(T entity);
        public void DeleteEntity(T entity);
        public Task<bool> SaveChangesAsync();
        public IQueryable<T> Query();
        public Task<IReadOnlyList<T>> GetListWithSpecAsync(ISpecification<T> specification);
}
