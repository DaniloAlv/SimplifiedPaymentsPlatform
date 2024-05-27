using MediatR;
using SimplifiedPaymentsPlatform.Application.Responses;

namespace SimplifiedPaymentsPlatform.Application.Commands;

public class UserByIdCommand : IRequest<UserViewModel>
{
    public UserByIdCommand(string userId)
    {
        Id = userId;
    }

    public string Id { get; }
}