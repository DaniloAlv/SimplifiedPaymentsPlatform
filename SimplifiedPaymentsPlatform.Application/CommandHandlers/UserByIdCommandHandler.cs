using MediatR;
using SimplifiedPaymentsPlatform.Application.Commands;
using SimplifiedPaymentsPlatform.Application.Mappings;
using SimplifiedPaymentsPlatform.Application.Responses;
using SimplifiedPaymentsPlatform.Domain.Repositories;

namespace SimplifiedPaymentsPlatform.Application.CommandHandlers;

public class UserByIdCommandHandler : IRequestHandler<UserByIdCommand, UserViewModel>
{
    private readonly IUserRepository _userRepository;

    public UserByIdCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserViewModel> Handle(UserByIdCommand request, CancellationToken cancellationToken)
    {
        var userById = await _userRepository.GetByIdAsync(request.Id);
        var userModel = userById.UserToModel();

        return userModel;
    }
}
