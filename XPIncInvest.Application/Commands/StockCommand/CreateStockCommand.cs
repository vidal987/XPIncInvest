using MediatR;
using System.ComponentModel.DataAnnotations;
using XPIncInvest.Domain.Enums;

namespace XPIncInvest.Application.Commands.StockCommand
{

    public class CreateStockCommand : IRequest<string> 
    {
        [Required]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")] 
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)] [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime DueDate { get; set; }

        [Required]
        public Category Category { get; set; }

        [EmailAddress(ErrorMessage = "O campo UserEmail não é um endereço de email válido. ")] 
        [Required]
        public string UserEmail { get; set; }
    }

    
}
