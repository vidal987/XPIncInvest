using XPIncInvest.Domain.Enums;
using XPIncInvest.Domain.Exceptions;
using XPIncInvest.Domain.Primitives;

namespace XPIncInvest.Domain.Entities.StockEntity
{
    public class Stock : Entity
    {
        public Stock()
        {
            
        }

        public Stock(string name, int quantity, decimal price, DateTime dueDate, Category category)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            DueDate = DateTime.SpecifyKind(dueDate, DateTimeKind.Utc);
            Category = category;
            IsActived = true;
        }

        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DueDate { get; private set; }
        public Category Category { get; private set; }
        public bool IsActived { get; private set; }


        public void ChangePrice(decimal price)
        {
            Price = price;
        }

        public void SellStock(int quantity)
        {
            //VALIDAÇÃO DA DATA DE VENCIMENTO DO TITULO.
            if (DueDate == DateTime.Now.ToLocalTime())
            {
                throw new DomainException("Title expired");
            }

            //VALIDACAO SE A QUANTIDADE DE TITULO É SUPERIOR A ZERO PARA VENDA.
            if (Quantity == 0)
            {
                throw new DomainException("It is not possible to sell this stock as there are no more units");
            }

            //VALIDACAO QUE VERIFICA SE A QUANTIDADE DE TITULOS A SEREM COMPRADOS É MAIOR QUE A QUANTIDADE ATUAL.
            if (quantity > Quantity)
            {
                throw new DomainException("We do not have that amount of stock's for sale");
            }

            Quantity -= quantity;
        }

        public void InactivedStock()
        {
            //Inativa o titulo depois que vencido;
            IsActived &= !IsActived;
        }
    }
}
