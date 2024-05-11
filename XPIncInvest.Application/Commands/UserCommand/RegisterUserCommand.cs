using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using XPIncInvest.Domain.Enums;

namespace XPIncInvest.Application.Commands.UserCommand
{
    public class RegisterUserCommand : IRequest<string>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
