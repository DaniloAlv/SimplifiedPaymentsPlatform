using System.ComponentModel.DataAnnotations;
using MediatR;
using SimplifiedPaymentsPlatform.Application.Responses;

namespace SimplifiedPaymentsPlatform.Application.Commands;

public class CreateUserCommand : IRequest<UserViewModel>
{
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    public string Document { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    public int Type { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public decimal WalletBalance { get; set; }
}