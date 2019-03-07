using Account.Domain.Contracts.UnitiesOfWork;
using System;

namespace Account.Infraestructure.UnitiesOfWork
{
    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IUnitOfWork _unitOfWork;

        public EFUnitOfWorkFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return _unitOfWork;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        ~EFUnitOfWorkFactory()
        {
            Dispose(false);
        }
    }
}
