using Account.Domain.Entity;
using Account.Domain.Interfaces;
using Account.Infraestructure.Data;
using Account.Infraestructure.Repositories.Base;

namespace Account.Infraestructure.Repositories
{
    public class CheckingAccountRepository : Repository<CheckingAccount>, ICheckingAccountRepository
    {
        public CheckingAccountRepository(CheckingAccountContext dbContext) : base(dbContext)
        {

        }
    }
}
