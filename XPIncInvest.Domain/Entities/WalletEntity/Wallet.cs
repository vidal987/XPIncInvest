using System.ComponentModel.DataAnnotations.Schema;
using XPIncInvest.Domain.Entities.StockEntity;
using XPIncInvest.Domain.Entities.UserEntity;
using XPIncInvest.Domain.Primitives;

namespace XPIncInvest.Domain.Entities.WalletEntity
{
    public class Wallet : Entity
    {
        private readonly List<Stock> _stocks;

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Wallet()
        {
            _stocks = new List<Stock>();
        }

        public virtual IReadOnlyCollection<Stock> Stocks => _stocks;

        public void AddStock(Stock stock)
        {
            _stocks.Add(stock); 
        }

        public void RemoveStock(Stock stock) 
        {
            _stocks.Remove(stock);
        }

    }
}
