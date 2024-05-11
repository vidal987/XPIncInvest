using Microsoft.EntityFrameworkCore;
using XPIncInvest.Domain.Entities.UserEntity;
using XPIncInvest.Infrastructure.Context;

namespace XPIncInvest.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return DbSet
                .FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
