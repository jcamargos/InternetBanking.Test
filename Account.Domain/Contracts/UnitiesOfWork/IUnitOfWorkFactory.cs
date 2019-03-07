using System;

namespace Account.Domain.Contracts.UnitiesOfWork
{
    public interface IUnitOfWorkFactory : IDisposable
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
