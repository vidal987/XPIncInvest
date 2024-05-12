using MediatR;
using System.ComponentModel.DataAnnotations;
using XPIncInvest.Domain.Enums;

namespace XPIncInvest.Application.Commands.StockCommand
{
    public class UpdateStockCommand : IRequest<string>
    {
        [Required]
        public Guid Id { get; set; }
        public bool? Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]

        public decimal? Price{ get; set; }

        public Category? Category { get; set; }

        [EmailAddress(ErrorMessage = "O campo UserEmail não é um endereço de email válido. ")]
        [Required]
        public string UserEmail { get; set; }
    }
}
