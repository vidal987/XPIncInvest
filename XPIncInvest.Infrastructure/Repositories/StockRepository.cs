using Microsoft.EntityFrameworkCore;
using XPIncInvest.Domain.Entities.StockEntity;
using XPIncInvest.Infrastructure.Context;

namespace XPIncInvest.Infrastructure.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> ExistByNameIdAsync(string name)
        {
            return await DbSet.AnyAsync(s => s.Name == name); ;
        }

    }
}
