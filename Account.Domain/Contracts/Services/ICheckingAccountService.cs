using Account.Domain.Contracts.Services.Base;
using Account.Domain.Entity;


namespace Account.Domain.Contracts.Services
{
    public interface ICheckingAccountService : IService<CheckingAccount>
    {
        void Credit(CheckingAccount entity, decimal value);
        void Debit(CheckingAccount entity, decimal value);
    }
}
