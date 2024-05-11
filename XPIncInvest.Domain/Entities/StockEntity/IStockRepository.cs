using XPIncInvest.BuildingBlocks.Extensions.Interfaces;
using XPIncInvest.Infrastructure.Context;

namespace XPIncInvest.Domain.Entities.StockEntity
{
    public interface IStockRepository : IRepository<Stock>, IScopedService
    {
        Task<bool> ExistByNameIdAsync (string name);
    }
}
