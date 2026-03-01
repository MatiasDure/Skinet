using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public abstract class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Criteria { get; protected set; }

    public Expression<Func<T, object>>? OrderBy { get; protected set; }

    public Expression<Func<T, object>>? OrderByDescending { get; protected set; }
}
