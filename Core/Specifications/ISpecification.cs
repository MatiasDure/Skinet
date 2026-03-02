using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public interface ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Criteria { get; }
    public Expression<Func<T, object>>? OrderBy { get; }
    public Expression<Func<T, object>>? OrderByDescending { get; }
    public int Take { get; }
    public int Skip { get; }
    public bool IsPaginationEnabled { get; }
}
