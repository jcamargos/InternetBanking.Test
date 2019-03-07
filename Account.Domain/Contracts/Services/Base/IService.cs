using Account.Domain.Entity;
using System.Collections.Generic;

namespace Account.Domain.Contracts.Services.Base
{
    public interface IService
    {

    }

    public interface IService<TEntity> : IService
       where TEntity : BaseEntity
    {
        TEntity Update(TEntity entity);

        TEntity Save(TEntity entity);
        IEnumerable<TEntity> Save(IEnumerable<TEntity> entities);
        TEntity Delete(long id);
        TEntity Get(long id);
        TEntity Get(long id, long recursoId);
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
    }
}

