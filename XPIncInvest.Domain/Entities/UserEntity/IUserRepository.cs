using XPIncInvest.BuildingBlocks.Extensions.Interfaces;
using XPIncInvest.Infrastructure.Context;

namespace XPIncInvest.Domain.Entities.UserEntity
{
    public interface IUserRepository : IRepository<User>, IScopedService
    {
        Task<User> GetByEmailAsync(string email);
    }
}
