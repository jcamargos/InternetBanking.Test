using Bank.Domain.Contracts.UnitiesOfWork;
using Bank.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bank.Infraestructure.UnitiesOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly BankContext _dbContext;

        public EFUnitOfWork(BankContext dbContext)
        {
            _dbContext = dbContext;

            if (_dbContext.Database != null)
                _dbContext.Database.SetCommandTimeout(9000000);
        }



        public object GetTransaction()
        {
            return _dbContext;
        }

        public int Commit()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        public void Rollback()
        {
            try
            {
                _dbContext.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
        }
    }
}
