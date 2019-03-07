using Account.Domain.Contracts.Services;

namespace Account.Business
{
    public class UserService
    {
        private readonly IUserService userService;
        public UserService(IUserService _userService)
        {
            _userService = userService;
        }
    }
}
