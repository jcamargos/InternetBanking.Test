using System;

namespace Account.Domain.Contracts.UnitiesOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        object GetTransaction();
        int Commit();
        void Rollback();
    }
}
