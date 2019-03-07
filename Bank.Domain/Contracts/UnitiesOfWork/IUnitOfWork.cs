using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Contracts.UnitiesOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        object GetTransaction();
        int Commit();
        void Rollback();
    }
}
