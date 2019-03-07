using Account.Domain.Contracts.Services;

namespace Account.Business
{
    public class CheckingAccountService
    {
        private readonly ICheckingAccountService checkingAccountService;
        public CheckingAccountService(ICheckingAccountService _checkingAccountService)
        {
            _checkingAccountService = checkingAccountService;
        }
    }
}
