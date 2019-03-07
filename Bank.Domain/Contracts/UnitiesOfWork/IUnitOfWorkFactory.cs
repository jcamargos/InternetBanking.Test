using System;

namespace Bank.Domain.Contracts.UnitiesOfWork
{
    public interface IUnitOfWorkFactory : IDisposable
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
