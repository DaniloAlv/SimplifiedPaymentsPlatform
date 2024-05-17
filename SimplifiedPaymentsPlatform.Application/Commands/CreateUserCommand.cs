using MediatR;
using SimplifiedPaymentsPlatform.Application.Responses;

namespace SimplifiedPaymentsPlatform.Application.Commands;

public class CreateUserCommand : IRequest<UserViewModel>
{
    public string Name { get; set; }
    public string Document { get; set; }
    public int Type { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public decimal WalletBalance { get; set; }
}