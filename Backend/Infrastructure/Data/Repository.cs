using System;
using System.Threading.Tasks;
using Application;
using Core.Entities;
using Core.Specifications;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class Repository<T>: IRepository<T> where T: BaseEntity
{
    protected readonly StoreContext _context;

    public Repository(StoreContext context)
    {
        _context = context;
    }

    public void AddEntity(T entity) => _context.Set<T>().Add(entity);

    public async Task<int> CountAsync(ISpecification<T> specification) => await specification.ApplyCriteria(_context.Set<T>().AsQueryable()).CountAsync();

    public void DeleteEntity(T entity) => _context.Set<T>().Remove(entity);

    public async Task<T?> GetEntityByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

    public async Task<IReadOnlyList<T>> GetListAsync() => await _context.Set<T>().ToListAsync();

    public async Task<IReadOnlyList<T>> GetListWithSpecAsync(ISpecification<T> specification) => await SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification).ToListAsync();
    
    public IQueryable<T> Query() => _context.Set<T>();

    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}
