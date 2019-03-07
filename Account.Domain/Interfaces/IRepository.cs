using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Account.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        IEnumerable<TEntity> All();
        TEntity FindById(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
