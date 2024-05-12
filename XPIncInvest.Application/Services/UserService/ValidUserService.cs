using XPIncInvest.Application.Exceptions;
using XPIncInvest.BuildingBlocks.Extensions.Interfaces;
using XPIncInvest.Domain.Entities.UserEntity;

namespace XPIncInvest.Application.Services.UserService
{
    public class ValidUserService(IUserRepository userRepository) : IScopedService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task ValidateUserAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email).ConfigureAwait(false);

            if (user is null)
            {
                throw new ValidationException("User not exists");
            }

            if (user.Role != Domain.Enums.Role.Admin)
            {
                throw new ValidationException("User is not admin, and cannot create a stock");
            }
        }
    }
}
