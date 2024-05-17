using MediatR;
using SimplifiedPaymentsPlatform.Application.Commands;
using SimplifiedPaymentsPlatform.Application.Mappings;
using SimplifiedPaymentsPlatform.Application.Responses;
using SimplifiedPaymentsPlatform.Domain.Repositories;

namespace SimplifiedPaymentsPlatform.Application.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserViewModel>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.CommandToUser();
        await _userRepository.Register(user);

        return user.UserToModel();
    }
}
