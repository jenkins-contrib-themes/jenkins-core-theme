using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GetCompliance.Infra.Data.Interfaces
{
    public interface IReadOnlyRepository<T>
    {
        T FindBy(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
